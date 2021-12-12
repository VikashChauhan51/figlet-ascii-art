﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigletFontArt;

/// <summary>
/// An object pool for merging references to identical strings.
/// </summary>
/// <remarks>
/// Unlike string interning (which is not available in <c>netstandard1.3</c> anyway)
/// the pool may be released and garbage collected.
/// </remarks>
public sealed class StringPool
{
    private readonly Dictionary<string, string> _pool = new Dictionary<string, string>(StringComparer.Ordinal);

    /// <summary>
    /// Returns a reference to a string equal to <paramref name="s"/> from the pool.
    /// If no such string exists within the pool, it is added, and <paramref name="s"/> is returned.
    /// </summary>
    /// <param name="s">The string to pool.</param>
    /// <returns>A reference to the pooled string.</returns>
    public string Pool(string s)
    {
        if (_pool.TryGetValue(s, out var pooled))
            return pooled;

        _pool[s] = s;
        return s;
    }
}
