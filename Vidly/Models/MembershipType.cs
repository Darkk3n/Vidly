﻿namespace Vidly.Models
{
   public class MembershipType
   {
      public byte Id { get; set; }
      public short SignUpFee { get; set; }
      public byte DurationInMonth { get; set; }
      public byte DiscountFee { get; set; }
      public string Name { get; set; }

      public static readonly byte Unknown = 0;
      public static readonly byte PayAsYouGo = 1;
   }
}