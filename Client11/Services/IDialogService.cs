using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Services
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string title, RenderFragment body, DialogOptions options = null);
        Task<bool> ShowConfirmationDialogAsync(string title, string message, string yesText = "Yes", string noText = "No", DialogOptions options = null);
    }

}
