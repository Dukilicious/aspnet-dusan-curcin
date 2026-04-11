using System.Reflection.Metadata.Ecma335;
using CoreFitness.Application.MembershipPlans;
using CoreFitness.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Presentation.Controllers;

public class MembershipsController(IMembershipPlanService membershipPlanService) : Controller
{
    public async Task <IActionResult> Index()
    {
        var vm = new MembershipsViewModel
        {
            MembershipPlans = await membershipPlanService.GetMembershipsPlansAsync()
        };

        return View(vm);
    }
}