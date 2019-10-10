using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pets.Tests
{
  public static class TestingInMemoryRoot
  {
    private static InMemoryDatabaseRoot _inMemoryDatabaseRoot;

    public static InMemoryDatabaseRoot GetInMemoryDatabaseRootInstance() => _inMemoryDatabaseRoot = _inMemoryDatabaseRoot ?? new InMemoryDatabaseRoot();
  }

}
