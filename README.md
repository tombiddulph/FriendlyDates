## Friendly Dates

A silly project to provide either `DateTime` `DateOnly` or `DatetimeOffset` in a friendly format.


Reference one of the packages and use as follows. Referencing multiple packages will cause conflicts as the extension methods become ambiguous.

## Usage

```csharp
using FriendlyDateonlys;

var dateOnly = 2.December(2020);
```

```csharp
using FriendlyDateTimes;

DateTime dateTime = 2.December(2020).At(12, 30);
```

```csharp
using FriendlyDateTimeOffsets;

DateTimeOffset dateTimeOffset = 2.December(2020);
```

## Why?

why not.