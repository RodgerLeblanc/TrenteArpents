using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrenteArpents.ViewModels;

namespace TrenteArpents.Extensions
{
    public static class TaskExtensions
    {
        public static async Task SetIsBusy(this Task task, IBusyViewModel viewModel)
        {
            if (task == null || viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            viewModel.IsBusy = true;

            try
            {
                await task;
            }
            finally
            {
                viewModel.IsBusy = false;
            }
        }

        public static async Task<T> SetIsBusy<T>(this Task<T> task, IBusyViewModel viewModel)
        {
            if (task == null || viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }

            viewModel.IsBusy = true;

            try
            {
                T result = await task;
                return result;
            }
            finally
            {
                viewModel.IsBusy = false;
            }
        }
    }
}
