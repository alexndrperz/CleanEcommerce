using System;
using System.Collections.Generic;
using System.Text;

namespace CleanEcomm.Domain.Common;
    public class Result {
        public bool IsSuccess { get; }
        public string Error { get; }

        protected Result(bool success, string error) {
            IsSuccess = success;
            Error = error;
        }

        public static Result Success() => new(true, null);
        public static Result Failure(string error) => new(false, error);
    }

    public class Result<T> : Result {
        public T Value { get; }

        protected Result(T value) : base(true, null) {
            Value = value;
        }

        protected Result(string error) : base(false, error) { }

        public static Result<T> Success(T value) => new(value);
        public static Result<T> Failure(string error) => new(error);
    }


