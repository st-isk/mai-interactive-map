using Microsoft.AspNetCore.Components;
using Plan3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Plan3.Pages
{
    public partial class Index
    {
        [Inject]
        ScheduleService ScheduleService { get; set; }
        [Inject]
        IJSRuntime JSinterop { get; set; }

        private int floor = 4;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var occupied = await ScheduleService.GetOccupiedAsync(floor);
                await JSinterop.InvokeVoidAsync("subscribeToClick");
                await JSinterop.InvokeVoidAsync("setOccupied", occupied);
            }
            
            

        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var timer = new System.Threading.Timer((_) =>
            {
                InvokeAsync(() =>
                {
                    var occupied = ScheduleService.GetOccupiedAsync(floor);
                    JSinterop.InvokeVoidAsync("setOccupied", occupied);
                    StateHasChanged();
                });
            }, null, 0, 1000);
        }
    }
}
