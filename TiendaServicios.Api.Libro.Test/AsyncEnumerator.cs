using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TiendaServicios.Api.Libro.Test
{
    public class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> enumerator;

        public AsyncEnumerator(IEnumerator<T> enumerator) =>
            this.enumerator = enumerator ?? throw new ArgumentNullException();

        public T Current => enumerator.Current;
        public async ValueTask DisposeAsync()
        {
            await Task.CompletedTask;
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(enumerator.MoveNext());
        }
    }
}
