﻿using System.Text.RegularExpressions;

using Microsoft.Recognizers.Definitions.Turkish;

namespace Microsoft.Recognizers.Text.DateTime.Turkish
{
    public class TurkishSetExtractorConfiguration : BaseOptionsConfiguration, ISetExtractorConfiguration
    {
        public static readonly Regex SetUnitRegex =
            new Regex(DateTimeDefinitions.DurationUnitRegex, RegexFlags);

        public static readonly Regex PeriodicRegex =
            new Regex(DateTimeDefinitions.PeriodicRegex, RegexFlags);

        public static readonly Regex EachUnitRegex =
            new Regex(DateTimeDefinitions.EachUnitRegex, RegexFlags);

        public static readonly Regex EachPrefixRegex =
            new Regex(DateTimeDefinitions.EachPrefixRegex, RegexFlags);

        public static readonly Regex SetLastRegex =
            new Regex(DateTimeDefinitions.SetLastRegex, RegexFlags);

        public static readonly Regex EachDayRegex =
            new Regex(DateTimeDefinitions.EachDayRegex, RegexFlags);

        public static readonly Regex SetWeekDayRegex =
            new Regex(DateTimeDefinitions.SetWeekDayRegex, RegexFlags);

        public static readonly Regex SetEachRegex =
            new Regex(DateTimeDefinitions.SetEachRegex, RegexFlags);

        private const RegexOptions RegexFlags = RegexOptions.Singleline | RegexOptions.ExplicitCapture;

        public TurkishSetExtractorConfiguration(IOptionsConfiguration config)
            : base(config)
        {
            DurationExtractor = new BaseDurationExtractor(new TurkishDurationExtractorConfiguration(this));
            TimeExtractor = new BaseTimeExtractor(new TurkishTimeExtractorConfiguration(this));
            DateExtractor = new BaseDateExtractor(new TurkishDateExtractorConfiguration(this));
            DateTimeExtractor = new BaseDateTimeExtractor(new TurkishDateTimeExtractorConfiguration(this));
            DatePeriodExtractor = new BaseDatePeriodExtractor(new TurkishDatePeriodExtractorConfiguration(this));
            TimePeriodExtractor = new BaseTimePeriodExtractor(new TurkishTimePeriodExtractorConfiguration(this));
            DateTimePeriodExtractor = new BaseDateTimePeriodExtractor(new TurkishDateTimePeriodExtractorConfiguration(this));
        }

        public IDateTimeExtractor DurationExtractor { get; }

        public IDateTimeExtractor TimeExtractor { get; }

        public IDateExtractor DateExtractor { get; }

        public IDateTimeExtractor DateTimeExtractor { get; }

        public IDateTimeExtractor DatePeriodExtractor { get; }

        public IDateTimeExtractor TimePeriodExtractor { get; }

        public IDateTimeExtractor DateTimePeriodExtractor { get; }

        Regex ISetExtractorConfiguration.LastRegex => SetLastRegex;

        Regex ISetExtractorConfiguration.EachPrefixRegex => EachPrefixRegex;

        Regex ISetExtractorConfiguration.PeriodicRegex => PeriodicRegex;

        Regex ISetExtractorConfiguration.EachUnitRegex => EachUnitRegex;

        Regex ISetExtractorConfiguration.EachDayRegex => EachDayRegex;

        Regex ISetExtractorConfiguration.BeforeEachDayRegex => null;

        Regex ISetExtractorConfiguration.SetWeekDayRegex => SetWeekDayRegex;

        Regex ISetExtractorConfiguration.SetEachRegex => SetEachRegex;
    }
}