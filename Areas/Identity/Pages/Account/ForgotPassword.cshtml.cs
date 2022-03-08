using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using asistencia_rips_APP.Models;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using asistencia_rips_APP.Data;
using System.Linq;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;

namespace asistencia_rips_APP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        //private readonly IEmailSender _emailSender;

        //public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            /*[Required(ErrorMessage = "El campo {0} es obligatorio")]
            [EmailAddress]
            [Display(Name = "Correo")]
            public string Email { get; set; }*/

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [Display(Name = "Usuario")]
            public string usuario { get; set; }
        }

        /// <summary>
        /// Envia correo de recuperación de contraseña a un email especifico.
        /// </summary>
        /// <returns>Respuesta "SI" o "NO" fue satisfactorio el envio</returns>
        public async Task<IActionResult> OnPostAsync()

        {
            //Valido que los valores no lleguen vacios
            if (Input.usuario != null && await _userManager.FindByNameAsync(Input.usuario) != null)
            {
                var user = await _userManager.FindByNameAsync(Input.usuario);

                //invoco metodo que permite obtener los datos del smtp del correo
                var confcorreo = await _context.Configcorreo.FirstOrDefaultAsync(m => m.is_Active == true);
                //_context.Configcorreo.Where(c => c.is_Active == true).First();
                //creo una variable para manejar los mensajes
                var MSG = new List<object>();
                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                try
                {
                    // create email message
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse(confcorreo.Username));
                    email.To.Add(MailboxAddress.Parse(user.Email.ToLower()));
                    email.Subject = "Recuperar Contraseña";
                    email.Body = new TextPart(TextFormat.Html) { Text = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>." };

                    var client = new SmtpClient();
                    client.Connect(confcorreo.Host, confcorreo.Port, SecureSocketOptions.StartTls);
                    client.Authenticate(confcorreo.Username, confcorreo.Password);
                    client.Send(email);
                    client.Disconnect(true);

                    return RedirectToPage("./ForgotPasswordConfirmation");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Error", "Se presento un problema al generar la recuperación de contraseña");
                    //return RedirectToPage("./ForgotPasswordConfirmation");
                }
            }
            else
            {
                ModelState.AddModelError("Error", "Error datos no existen");
            }
            return Page();
        }

    }
}
