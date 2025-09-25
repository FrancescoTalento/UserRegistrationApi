using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Authorization
{
    public class MinimumAge : IAuthorizationRequirement
    {
        public int Age { get; set; }
        public MinimumAge(int age)
        {
            this.Age = age;
        }
    }
}
