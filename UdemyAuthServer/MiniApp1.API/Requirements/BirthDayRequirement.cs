using Microsoft.AspNetCore.Authorization;

namespace MiniApp1.API.Requirements
{
    public class BirthDayRequirement:IAuthorizationRequirement
    {
        public int Age { get; set; }

        public BirthDayRequirement(int age)
        {
            Age = age;
        }
    }

    public class BirthDayRequirementHandler : AuthorizationHandler<BirthDayRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BirthDayRequirement requirement)
        {

            var birthDate = Convert.ToDateTime( context.User.FindFirst("birth-date").Value.ToString());
            if (birthDate == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var today = DateTime.Now;
            var age =  today.Year - birthDate.Year;
            if (age >= requirement.Age)
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
           

        }
    }
}
