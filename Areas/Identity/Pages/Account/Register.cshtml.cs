using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using asistencia_rips_APP.Models;

namespace asistencia_rips_APP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        /*private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;*/
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            /*UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,*/
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender
            )
                {
                    _userManager = userManager;
                    _signInManager = signInManager;
                    _logger = logger;
                    _emailSender = emailSender;
                }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [StringLength(256, ErrorMessage = "El campo {0} debe tener un mínimo {2} y un maximo de {1} caracteres de longitud.", MinimumLength = 3)]
            [Display(Name = "Nombres")]
            public string Names { get; set; }

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [StringLength(256, ErrorMessage = "El campo {0} debe tener un mínimo {2} y un maximo de {1} caracteres de longitud.", MinimumLength = 3)]
            [Display(Name = "Apellidos ")]
            public string LastNames { get; set; }

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [StringLength(100, ErrorMessage = "El campo {0} debe tener un mínimo {2} y un maximo de {1} caracteres de longitud.", MinimumLength = 3)]
            [Display(Name = "Usuario")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [Range(0, int.MaxValue, ErrorMessage = "Por favor ingrese solo números para este campo")]
            [Display(Name = "Número de Extensión")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [EmailAddress(ErrorMessage = "El campo {0} debe ser un correo electronico valido")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo {0} es obligatorio")]
            [StringLength(100, ErrorMessage = "El campo {0} debe tener un mínimo {2} y un maximo de {1} caracteres de longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coincide.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id= Guid.NewGuid().ToString(),
                    FirstName = Input.Names,
                    LastName = Input.LastNames,
                    UserName = Input.UserName,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                };

                //var user = new IdentityUser { UserName = Input.UserName, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    
                    _logger.LogInformation("Usuario creado una nueva cuenta con contraseña.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/Login",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Por favor confirme su cuenta para <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'> opima aquí</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
