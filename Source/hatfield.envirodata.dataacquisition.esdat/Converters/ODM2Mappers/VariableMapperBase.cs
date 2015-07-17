﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class VariableMapperBase : ESDATMapperBase<Variable>, IODM2DuplicableMapper<Variable>
    {
        List<Variable> _backingStore;

        public VariableMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Variable> backingStore)
        {
            _backingStore = backingStore;
        }

        public Variable GetDuplicate(WayToHandleNewData wayToHandleNewData, Variable entity)
        {
            var duplicate = entity;

            try
            {
                duplicate = _duplicateChecker.GetDuplicate<Variable>(entity, x =>
                    x.VariableTypeCV.Equals(entity.VariableTypeCV),
                    wayToHandleNewData,
                    _backingStore
                );
            }
            catch (KeyNotFoundException)
            {
                var location = new MapperSourceLocation(this.ToString(), null);
                LogNotFoundInDatabaseException(location);
            }

            return duplicate;
        }
    }
}
