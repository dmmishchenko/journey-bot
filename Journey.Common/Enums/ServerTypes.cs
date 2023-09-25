﻿using System.ComponentModel;
using System.Reflection;

namespace Journey.Common.Enums
{

    public class ServerTypes
    {
        public enum ServerErrorCodes : int
        {
            None = 0,
            HttpError = 1,
            ApiError = 2,
            InvalidData = 3,
            ConnectionStringError = 4,
            WebResourceLoadError = 5,
        }

        public enum ServerMessageTypes : byte
        {
            None = 0,
            Information = 1,
            Warning = 2,
            Error = 3,
            Critical = 4
        }
    }

    public static class ServerTypesExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return string.Empty;

            FieldInfo field = value.GetType().GetField(value.ToString());

            return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
        }
    }
}
