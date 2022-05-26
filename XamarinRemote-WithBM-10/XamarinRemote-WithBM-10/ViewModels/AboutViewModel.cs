using Plugin.BLE;
using Plugin.BLE.Abstractions.Exceptions;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinRemote_WithBM_10.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        bool searching;
        public AboutViewModel()
        {
            Title = "About";
            TryToConnect = new Command(async () =>
            {
                searching = true;
                var ble = CrossBluetoothLE.Current;
                var adapter = CrossBluetoothLE.Current.Adapter;
                var perm = await CrossPermissions.Current.CheckPermissionStatusAsync<LocationPermission>();
                if(perm != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    perm = await CrossPermissions.Current.RequestPermissionAsync<LocationPermission>();
                }
                if (perm == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    await App.Current.MainPage.DisplayAlert("Searching", "Started a device search.", "OK");
                    adapter.DeviceDiscovered += async (s, a) =>
                    {
                        var device = a.Device;
                        Console.WriteLine("Found " + device.Name);
                        try
                        {
                            if (device.Name.Contains("ROBOT"))
                            {
                                try
                                {
                                    await adapter.StopScanningForDevicesAsync();
                                    await adapter.ConnectToDeviceAsync(device);
                                    await Application.Current.MainPage.DisplayAlert("Successful", "Connected to the device.", "OK");
                                }
                                catch (DeviceConnectionException e)
                                {
                                    await Application.Current.MainPage.DisplayAlert("Error", "Couldn't connect to the device.", "OK");
                                }
                            }
                            else
                                Console.WriteLine("Wasn't robot..");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                            
                    };
                    await adapter.StartScanningForDevicesAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Can't use bluetooth.", "OK");
                }
            });
            StopConnect = new Command(async () =>
            {
                if (!searching)
                    return;
                var ble = CrossBluetoothLE.Current;
                var adapter = CrossBluetoothLE.Current.Adapter;
                await adapter.StopScanningForDevicesAsync();
            });
        }

        public ICommand TryToConnect { get; }
        public ICommand StopConnect { get; }
    }
}