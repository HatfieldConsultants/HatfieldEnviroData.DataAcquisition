﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ChemistryActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.AnalysedDate = DateTime.Now;

            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATChemistryParameters(mockDbContext, esdatModel, sample, chemistry);
            var factory = new ESDATChemistryMapperSingletonFactory(parameters);
            var mapper = new ChemistryActionMapper(factory, parameters);

            var action = mapper.Scaffold();

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("Specimen analysis", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(chemistry.AnalysedDate, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }
    }
}
