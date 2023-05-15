﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace JaguarLibraryControls
{
    public class EnumBindingSource: MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSource(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new Exception("EnuType must not be null and of type Enum");

            EnumType = enumType;
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
