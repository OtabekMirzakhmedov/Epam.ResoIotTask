using Epam.ResoIotTask.DTOs;
using FluentValidation;

namespace Epam.ResoIotTask.Validations
{
    public class TelemetryDataValidator: AbstractValidator<TelemetryDataInput>, ITelemetryDataValidator
    {
        public TelemetryDataValidator()
        {
            RuleFor(telemetry => telemetry.Illuminance)
                .Must(BeAValidIlluminance)
                .WithSeverity(Severity.Error);
        }

        public bool IsValidIlluminance(TelemetryDataInput telemetry)
        {
            return this.Validate(telemetry).IsValid;
        }

        private bool BeAValidIlluminance(double illuminance)
        {
            return illuminance % 0.5 == 0;
        }
    }
}
