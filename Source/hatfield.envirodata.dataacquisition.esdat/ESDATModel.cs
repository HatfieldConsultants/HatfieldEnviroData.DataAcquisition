﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATModel
    {
        //Header file properties
        public DateTime DateReported { get; set; }
        public int ProjectId { get; set; }
        public string LabName { get; set; }
        public string LabSignatory { get; set; }
        public List<string> AssociatedFiles { get; set; }
        public List<string> CopiesSentTo { get; set; }
        public int SDGID { get; set; }
        public int COCNumber { get; set; }
        public int LabRequestId { get; set; }
        public int LabRequestNumber { get; set; }
        public decimal LabRequestVersion { get; set; }
        public SampleFileData SampleFileData { get; set; }
        public IEnumerable<ChemistryFileData> ChemistryData { get; set; }

        public ESDATModel()
        {
            DateReported = new DateTime();
            AssociatedFiles = new List<string>();
            CopiesSentTo = new List<string>();
            SampleFileData = new SampleFileData();
            ChemistryFileData chemistryData = new ChemistryFileData();
            List<ChemistryFileData> chemistryDataList = new List<ChemistryFileData>();
            chemistryDataList.Add(chemistryData);
            ChemistryData = chemistryDataList;
        }

        public ESDATModel(DateTime dateReported, int projectID, string labName, string labSignatory, List<string> associatedFiles, List<string> copiesSentTo, int sdgid, int cocNumber, int labRequestID, int labRequestNumber, decimal labRequestVersion, SampleFileData sampleFileData, IEnumerable<ChemistryFileData> chemistryData)
        {
            DateReported = dateReported;
            ProjectId = projectID;
            LabName = labName;
            LabSignatory = labSignatory;
            AssociatedFiles = associatedFiles;
            CopiesSentTo = copiesSentTo;
            SDGID = sdgid;
            COCNumber = cocNumber;
            LabRequestId = labRequestID;
            LabRequestNumber = labRequestNumber;
            LabRequestVersion = labRequestVersion;
            SampleFileData = sampleFileData;
            ChemistryData = chemistryData;
        }
    }
}
