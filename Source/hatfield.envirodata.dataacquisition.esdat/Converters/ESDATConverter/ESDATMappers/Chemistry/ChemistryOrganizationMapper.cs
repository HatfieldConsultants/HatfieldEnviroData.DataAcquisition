﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryOrganizationMapper : OrganizationMapperBase, IESDATChemistryMapper<Organization>
    {
        public SampleFileData SampleFileData { get; set; }

        public ChemistryOrganizationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Organization Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Organization Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Organization();

            var organizationName = SampleFileData.LabName;

            entity.OrganizationTypeCV = _WQDefaultValueProvider.OrganizationTypeCVChemistry;
            entity.OrganizationCode = GetOrganizationCode(organizationName);
            entity.OrganizationName = organizationName;
            entity.OrganizationDescription = null;
            entity.OrganizationLink = null;
            entity.ParentOrganizationID = null;

            Validate(entity);

            return entity;
        }
    }
}
