﻿using FluentValidation.Results;

namespace BS.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        public ResponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }

}
