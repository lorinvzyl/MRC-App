using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Services
{
    public interface ISecureStorageProvider
    {
        ISecureStorage SecureStorage { get;  }
    }
}
