﻿namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public enum MessageType
    {
        INFO,
        WARNING,
        ERROR,
        SUCCESS
    }

    public enum NotificationType
    {
        GENERAL
    }

    //
    // Summary:
    //     Specifies how rows of data are sorted.
    public enum SortOrder
    {
        //
        // Summary:
        //     The default. No sort order is specified.
        Unspecified = -1,
        //
        // Summary:
        //     Rows are sorted in ascending order.
        Ascending = 0,
        //
        // Summary:
        //     Rows are sorted in descending order.
        Descending = 1
    }
}
