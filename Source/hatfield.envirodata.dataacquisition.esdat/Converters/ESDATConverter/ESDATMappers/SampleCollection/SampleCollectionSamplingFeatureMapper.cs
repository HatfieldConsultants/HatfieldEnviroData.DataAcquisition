﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionSamplingFeatureMapper : SamplingFeatureMapperBase, IESDATSampleCollectionMapper<SamplingFeature>
    {
        public SampleCollectionSamplingFeatureMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public SamplingFeature Scaffold(ESDATModel esdatModel)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = _WQDefaultValueProvider.DefaultSamplingFeatureTypeCVSampleCollection;
            samplingFeature.SamplingFeatureCode = _WQDefaultValueProvider.DefaultSamplingFeatureCode;
            samplingFeature.SamplingFeatureUUID = new Guid();

            LogScaffoldingComplete(this);

            return samplingFeature;
        }
    }
}
