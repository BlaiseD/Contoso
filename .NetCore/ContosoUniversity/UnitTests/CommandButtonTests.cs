using AutoMapper;
using Contoso.Angular.Settings;
using Contoso.AutoMapperProfiles;
using LogicBuilder.Forms.Parameters;
using System;
using Xunit;

namespace UnitTests
{
    public class CommandButtonTests
    {
        public CommandButtonTests()
        {
            SetupAutoMapper();
        }
        #region Fields
        static IMapper mapper;
        #endregion Fields

        #region Methods
        [Fact]
        public void Map_ConnectorParameters_To_CommandButton()
        {
            ConnectorParameters parameters = new ConnectorParameters
            {
                Id = 1,
                ShortString = "EDT",
                LongString = "Edit",
                ConnectorData = new CommandButtonData
                {
                    ButtonIcon = "fa-step-forward",
                    Cancel = false,
                    ClassString = "btn-secondary",
                    GridCommandButton = true,
                    GridId = 1
                }
            };

            CommandButton button = mapper.Map<CommandButton>(parameters);
            Assert.Equal(1, button.Id);
            Assert.Equal("EDT", button.ShortString);
            Assert.Equal("Edit", button.LongString);
            Assert.Equal("fa-step-forward", button.ButtonIcon);
            Assert.False(button.Cancel);
            Assert.Equal("btn-secondary", button.ClassString);
            Assert.True(button.GridCommandButton);
            Assert.Equal(1, button.GridId);
        }

        [Fact]
        public void Map_CommandButton_To_ConnectorParameters()
        {
            CommandButton button = new CommandButton
            {
                Id = 1,
                ShortString = "EDT",
                LongString = "Edit",
                ButtonIcon = "fa-step-forward",
                Cancel = false,
                ClassString = "btn-secondary",
                GridCommandButton = true,
                GridId = 1
            };

            ConnectorParameters parameters = mapper.Map<ConnectorParameters>(button);
            CommandButtonData data = (CommandButtonData)parameters.ConnectorData;
            Assert.Equal(1, parameters.Id);
            Assert.Equal("EDT", parameters.ShortString);
            Assert.Equal("Edit", parameters.LongString);
            Assert.Equal("fa-step-forward", data.ButtonIcon);
            Assert.False(data.Cancel);
            Assert.Equal("btn-secondary", data.ClassString);
            Assert.True(data.GridCommandButton);
            Assert.Equal(1, data.GridId);
        }

        private static void SetupAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(ConnectorProfile));
            });
            config.AssertConfigurationIsValid<ConnectorProfile>();
            mapper = config.CreateMapper();
        }
        #endregion Methods
    }
}
