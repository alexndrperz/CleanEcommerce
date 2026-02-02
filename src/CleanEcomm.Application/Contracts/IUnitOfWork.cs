using System;
using System.Collections.Generic;
using System.Text;

namespace CleanEcomm.Application.Contracts;

public interface IUnitOfWork {
    Task CommitAsync(CancellationToken ct = default);
}

