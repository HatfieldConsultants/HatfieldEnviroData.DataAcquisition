﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.FileSystems.Filters
{
    public class FtpFileSystemFilter : IFileSystemFilter
    {
        public bool Meet(object value)
        {
            return true;
        }
    }
}
