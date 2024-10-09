using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class TradeModel : PageModel
    {
        public readonly IMasterService _MasterService;

        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notyf;
        public TradeModel(IMasterService masterService, UserManager<IdentityUser> UserManager, INotyfService notyf)
        {
            _MasterService = masterService;

            _UserManager = UserManager;
            _notyf = notyf;
        }

        public string userId { get; set; }
        [BindProperty]
        public Trade trade { get; set; } = new();
        public List<Trade> trades { get; set; } = new();
        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            if (Id > 0)
            {
                var tradedata = trades.Where(c => c.Id == Id).FirstOrDefault();
                if (tradedata != null)
                {
                    trade.Name = tradedata.Name;
                    trade.Id = tradedata.Id;
                    trade.IsActive = tradedata.IsActive;
                    trade.CreatedDate = tradedata.CreatedDate;
                    trade.CreatedBy = tradedata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                trade.IsActive = true;
            }
        }

        public async Task getData()
        {
            trades = await _MasterService.GetTrades();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (trade.Id == 0)
            {
                trade.CreatedDate = DateTime.Now;
                trade.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertTrade(trade);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            else
            {
                trade.UpdatedDate = DateTime.Now;
                trade.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateTrade(trade);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            await Reset();

            return Redirect("Trade");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteTrade(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return RedirectToPage("Trade");
        }

        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            trade = new Trade();
        }
    }
}
