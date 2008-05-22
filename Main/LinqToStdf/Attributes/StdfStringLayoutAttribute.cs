﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinqToStdf.Attributes {

    /// <summary>
    /// Indicates that the field is a character array.  The result will be a
    /// <see cref="String"/>. If a length is provided, it will be used,
    /// rather than the first byte of the field.
    /// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
	public class StdfStringLayoutAttribute : StdfFieldLayoutAttribute {

		public StdfStringLayoutAttribute() {
			base.FieldType = typeof(string);
			base.MissingValue = string.Empty;
		}

		private int _Length = int.MinValue;
        /// <summary>
        /// Indicates the length of the string.
        /// If not specified, the string will be a self-length string.
        /// </summary>
		public int Length {
			get { return _Length; }
			set { _Length = value; }
		}

        /// <summary>
        /// Overriden to be locked to string. setting is an invalid operation.
        /// </summary>
		public override Type FieldType {
			get { return base.FieldType; }
			set {
				if (value != typeof(string)) {
					throw new InvalidOperationException("StdfStringLayoutAttribute can only define fields of type string.");
				}
			}
		}
	
	}
}