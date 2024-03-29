using Capstone.data;
using Capstone.DTO.UserDTO;
using Capstone.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        public AuthController(ApplicationDbContext db, IConfiguration config)
        {
            _db = db;
            _configuration = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            var userDb = await _db.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (userDb == null)
            {
                return NotFound("User not found");
            }
            if (userDb.Password != user.Password)
            {
                return BadRequest("Invalid password");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name, userDb.Email.ToString()),
                new Claim(ClaimTypes.Role, userDb.Ruolo),
                new Claim(ClaimTypes.NameIdentifier, userDb.IdUser.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var authenticatedUser = new
            {
                Id = userDb.IdUser,
                Name = userDb.Nome,
                Surname = userDb.Cognome,
                Email = userDb.Email,
                City = userDb.Città,
                Address = userDb.Indirizzo,
                Token = tokenHandler.WriteToken(token)
            };
            return Ok(authenticatedUser);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegistrationDTO user)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var userDb = new User
            {
                Username = user.Username,
                Password = user.Password,
                Nome = user.Nome,
                Cognome = user.Cognome,
                Ruolo = "User",
                Email = user.Email,
                Cellulare = user.Cellulare,
                Città = user.Città,
                Indirizzo = user.Indirizzo,
                Cap = user.Cap,
                Longitudine = user.Longitudine,
                Latitudine = user.Latitudine,
                isOnline = true,
                Immagine = "img",
            };
            _db.Users.Add(userDb);
            _db.SaveChanges();

            return Ok();
        }
    }

}
