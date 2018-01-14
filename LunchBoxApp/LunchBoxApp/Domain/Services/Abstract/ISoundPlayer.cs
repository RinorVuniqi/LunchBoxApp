using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchBoxApp.Domain.Services.Abstract
{
    public interface ISoundPlayer
    {
        Task PlaySuccessSound();
        Task PlayDeniedSound();
    }
}
