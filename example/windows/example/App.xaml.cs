﻿using Microsoft.ReactNative;

namespace example
{
    sealed partial class App : ReactApplication
    {
        public App()
        {
            MainComponentName = "example";

#if BUNDLE
            JavaScriptBundleFile = "index.windows";
            InstanceSettings.UseWebDebugger = false;
            InstanceSettings.UseFastRefresh = false;
#else
            JavaScriptMainModuleName = "index";
            InstanceSettings.UseWebDebugger = false; // Set to false to get synchronous module methods calls to work, for example DeviceInfo.getSerialNumberSync()
            InstanceSettings.UseFastRefresh = true;
#endif

#if DEBUG
            InstanceSettings.EnableDeveloperMenu = true;
#else
            InstanceSettings.EnableDeveloperMenu = false;
#endif

            Microsoft.ReactNative.Managed.AutolinkedNativeModules.RegisterAutolinkedNativeModulePackages(PackageProviders); // Includes any autolinked modules
            
            PackageProviders.Add(new Microsoft.ReactNative.Managed.ReactPackageProvider()); // Includes any modules in this project

            PackageProviders.Add(new RNDeviceInfo.ReactPackageProvider()); // react-native-device-info module

            InitializeComponent();
        }
    }
}
