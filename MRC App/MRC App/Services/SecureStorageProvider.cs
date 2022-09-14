using Plugin.SecureStorage;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRC_App.Services
{
    public class SecureStorageProvider : ISecureStorageProvider
    {
        public ISecureStorage SecureStorage => CrossSecureStorage.Current;
    }
}
