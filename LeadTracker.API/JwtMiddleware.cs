using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeadTracker.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

//public class JwtMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly AppSetting _appSettings;
//    private readonly IConfiguration _configuration;

//    public JwtMiddleware(RequestDelegate next, IOptions<AppSetting> appSettings, IConfiguration configuration)
//    {
//        _next = next;
//        _appSettings = appSettings.Value;
//        _configuration = configuration;
//    }

//    public async Task Invoke(HttpContext context)
//    {
//        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
//        var attribute = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();
//        if (attribute != null)
//        {
//            await _next(context);
//        }

//        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

//        if (token != null)
//        {
//            await AddUserToContext(context, token);

//            await _next(context);

//        }
//        else
//        {
//            return;
//        }

//    }


//    private async Task AddUserToContext(HttpContext context, string token)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

//        tokenHandler.ValidateToken(token, new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = key,
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            ClockSkew = TimeSpan.Zero
//        }, out SecurityToken validatedToken);

//        var jwtToken = (JwtSecurityToken)validatedToken;
//        var userIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserId");
//        //var nameClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "Name");
//        //var emailIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "EmailId");
//        //var usernameClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserName");
//        var orgIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "OrgId");

//        if (userIdClaim != null)
//        {
//            var userId = int.Parse(userIdClaim.Value);
//            context.Items["UserId"] = userId;
//        }

//        //if (nameClaim != null)
//        //{
//        //    var name = nameClaim.Value;
//        //    context.Items["Name"] = name;
//        //}

//        //if (emailIdClaim != null)
//        //{
//        //    var emailId = emailIdClaim.Value;
//        //    context.Items["EmailId"] = emailId;
//        //}

//        //if (usernameClaim != null)
//        //{
//        //    var username = usernameClaim.Value;
//        //    context.Items["UserName"] = username;
//        //}

//        if (orgIdClaim != null)
//        {
//            var orgId = int.Parse(orgIdClaim.Value);
//            context.Items["OrgId"] = orgId;
//        }
//    }
//}

















//    //private async Task AddUserToContext(HttpContext context, string token)
//    //{
//    //    var tokenHandler = new JwtSecurityTokenHandler();

//    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));


//    //        tokenHandler.ValidateToken(token, new TokenValidationParameters
//    //        {
//    //            ValidateIssuerSigningKey = true,
//    //            IssuerSigningKey = key,
//    //            ValidateIssuer = false,
//    //            ValidateAudience = false,
//    //            ClockSkew = TimeSpan.Zero
//    //        }, out SecurityToken validatedToken);

//    //        var jwtToken = (JwtSecurityToken)validatedToken;
//    //        var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);
//    //        var name = jwtToken.Claims.FirstOrDefault(x => x.Type == "Name")?.Value;
//    //        var emailId = jwtToken.Claims.FirstOrDefault(x => x.Type == "EmailId")?.Value;
//    //        var username = jwtToken.Claims.FirstOrDefault(x => x.Type == "UserName")?.Value;
//    //        var orgId = int.Parse(jwtToken.Claims.First(x => x.Type == "OrgId").Value);



//    //        // Attach the user to the context on successful JWT validation
//    //        context.Items["UserId"] = userId;
//    //        context.Items["Name"] = name;
//    //        context.Items["EmailId"] = emailId;
//    //        context.Items["UserName"] = username;
//    //        context.Items["OrgId"] = orgId;


//    //}
//}



//public class JwtMiddleware
//{
//    private readonly RequestDelegate _next;
//    private readonly IConfiguration _configuration;

//    public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
//    {
//        _next = next;
//        _configuration = configuration;
//    }

//    public async Task Invoke(HttpContext context)
//    {
//        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
//        if (token != null)
//        {
//            var userId = ValidateToken(token);
//            if (userId.HasValue)
//            {
//                // Attach user ID to the context on successful JWT validation
//                context.Items["UserId"] = userId.Value;
//            }
//        }

//        await _next(context);
//    }

//    private int? ValidateToken(string token)
//    {
//        var tokenHandler = new JwtSecurityTokenHandler();
//        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
//        try
//        {
//            tokenHandler.ValidateToken(token, new TokenValidationParameters
//            {
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = new SymmetricSecurityKey(key),
//                ValidateIssuer = false,
//                ValidateAudience = false,
//                // Set clockskew to zero so tokens expire exactly at token expiration time
//                ClockSkew = TimeSpan.Zero
//            }, out SecurityToken validatedToken);

//            var jwtToken = (JwtSecurityToken)validatedToken;
//            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);

//            // Return user ID from JWT token if validation is successful
//            return userId;
//        }
//        catch
//        {
//            // Return null if validation fails
//            return null;
//        }
//    }
//}