using System;
using System.Linq;
using MobileManager.Models.Devices;
using MobileManager.Models.Devices.Interfaces;
using MobileManager.Configuration.Interfaces;
using MobileManager.SeleniumConfigs.DataSets.Interfaces;
using DotLiquid;

namespace MobileManager.SeleniumConfigs.DataSets
{
    /// <inheritdoc />
    /// <summary>
    /// IosSeleniumConfig.
    /// This class is dataset for DotLiquid text templating system.
    /// Inherits from DotLiquid/Drop class for data transform.
    /// </summary>
    public class IosSeleniumConfig : Drop, ISeleniumConfig
    {
        /// <summary>
        /// Initializes a new instance of the IosSeleniumConfig class.
        /// </summary>
        /// <param name="device">IDevice Device</param>
        /// <param name="configuration">IManagerConfiguration configuration</param>
        public IosSeleniumConfig(IDevice device, IManagerConfiguration configuration) { 
            this.Id = device.Id;
            this.Name = device.Name;
            this.AppiumEndpoint = device.AppiumEndpoint;
            this.Host = !string.IsNullOrEmpty(device.AppiumEndpoint) ? new Uri(device.AppiumEndpoint).Host : string.Empty;
            this.Port = !string.IsNullOrEmpty(device.AppiumEndpoint) ? new Uri(device.AppiumEndpoint).Port.ToString() : string.Empty;
            this.Version = device.Properties.First(x => x.Key == "ProductVersion").Value;
            this.TeamId = configuration.IosDeveloperCertificateTeamId;
        }

        /// <inheritdoc />
        /// <summary>
        /// Gets the Id.
        /// </summary>
        /// <value>The Id.</value>
        public string Id { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the Name.
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the AppiumEndpoint.
        /// </summary>
        /// <value>The AppiumEndpoint.</value>
        public string AppiumEndpoint { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the Host.
        /// </summary>
        /// <value>The Host.</value>
        public string Host { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the Port.
        /// </summary>
        /// <value>The Port.</value>
        public string Port { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the Version.
        /// </summary>
        /// <value>The Version.</value>
        public string Version { get; }

        /// <inheritdoc />
        /// <summary>
        /// Gets the TeamId.
        /// </summary>
        /// <value>The TeamId.</value>
        public string TeamId { get; }
    }

}