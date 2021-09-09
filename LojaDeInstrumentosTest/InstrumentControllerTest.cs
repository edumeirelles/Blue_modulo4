using FakeItEasy;
using LojaDeInstrumentosAPI.API;
using LojaDeInstrumentosAPI.Controllers;
using LojaDeInstrumentosAPI.Models;
using LojaDeInstrumentosAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LojaDeInstrumentosTest
{
    public class InstrumentControllerTest
    {
        int InstrumentQuantity = 10;
        List<Instrument> fakeInstrument;

        public InstrumentControllerTest()
        {
            fakeInstrument = new List<Instrument>();
            for (var i = 1; i <= InstrumentQuantity; i++)
                fakeInstrument.Add(new Instrument { Id = i, Brand = $"Instrumento {i}", Model = $"Modelo {i}" });          
        }
        [Fact]
        public void GetInstrument_Returns_The_Correct_Instrument()
        {
            var instrumentService = A.Fake<IInstrumentService>();
            A.CallTo(() => instrumentService.All()).Returns(fakeInstrument);
            var controller = new InstrumentController(instrumentService);

            OkObjectResult result = controller.Index() as OkObjectResult;

            var values = result.Value as APIResponse<List<Instrument>>;

            Assert.True(
                values.Results == fakeInstrument &&
                values.Message == "" &&
                values.Succeed
                );
        }
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(0, "Não foi encontrado o produto solicitado.", false)]
        [InlineData(1250, "Não foi encontrado o produto solicitado.", false)]
        [InlineData(-328, "Não foi encontrado o produto solicitado.", false)]
        [InlineData(null, "Não foi encontrado o produto solicitado.", false)]
        [InlineData(13, "Não foi encontrado o produto solicitado.", false)]
        public void GetInstrument_Return_Instrument_By_Id(int? id, string message = "", bool succeed = true)
        {
            var instrumentService = A.Fake<IInstrumentService>();
            A.CallTo(() => instrumentService.Get(id)).Returns(fakeInstrument.Find(p => p.Id == id));

            var controller = new InstrumentController(instrumentService);

            ObjectResult result = controller.Index(id) as ObjectResult;

            var exists = fakeInstrument.Find(p => p.Id == id) != null;

            if (exists)
            {
                var values = result.Value as APIResponse<Instrument>;
                Assert.True(
                    values.Message == message &&
                    values.Succeed == succeed &&
                    values.Results == fakeInstrument.Find(p => p.Id == id)
                );
            }
            else
            {
                var values = result.Value as APIResponse<string>;
                Assert.True(
                    values.Message == message &&
                    values.Succeed == succeed &&
                    values.Results == null
                );
            }
        }
    }
}
