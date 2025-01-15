using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Services
{
    public class DialogService : IDialogService
    {
        public Task ShowDialogAsync(string title, RenderFragment body, DialogOptions options = null)
        {
            // Implement your dialog logic here
            return Task.CompletedTask;
        }

        public Task<bool> ShowConfirmationDialogAsync(string title, string message, string yesText = "Yes", string noText = "No", DialogOptions options = null)
        {
            // Implement your confirmation dialog logic here
            return Task.FromResult(true);
        }
    }

}
