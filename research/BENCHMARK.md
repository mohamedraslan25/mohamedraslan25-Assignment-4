# Benchmark Analysis

## Overview

This benchmark compares normal string concatenation using `+` with `StringBuilder` when repeatedly appending text.

The benchmark was performed using BenchmarkDotNet with different iteration counts:

- 100 iterations
- 1,000 iterations
- 10,000 iterations
- 100,000 iterations

`MemoryDiagnoser` was used to measure memory allocations.

## Results

| Iterations | String Concatenation | StringBuilder |
|---:|---:|---:|
| 100 | 8.973 μs | 1.943 μs |
| 1,000 | 817.981 μs | 24.055 μs |
| 10,000 | 163.269 ms | 453.482 μs |
| 100,000 | Pending | Pending |

> The 100,000 iteration results will be added after the benchmark finishes.

## Analysis

### 1. Which approach was faster with 100 iterations?

`StringBuilder` was faster.

For 100 iterations:

- String concatenation: **8.973 μs**
- StringBuilder: **1.943 μs**

### 2. Which approach was faster with 100,000 iterations?

The final BenchmarkDotNet result will be used to answer this question.

Based on the results from the smaller iteration counts, `StringBuilder` is expected to perform significantly better as the number of iterations increases.

### 3. Which approach allocated more memory?

The `Allocated` column from BenchmarkDotNet is used to answer this question.

Repeated string concatenation generally creates more temporary string objects because strings are immutable.

### 4. What happened to string concatenation performance as the loop size increased?

String concatenation became significantly slower as the number of iterations increased.

The measured results were:

- 100 iterations: **8.973 μs**
- 1,000 iterations: **817.981 μs**
- 10,000 iterations: **163.269 ms**

This shows that the execution time increased rapidly as the amount of repeated concatenation increased.

### 5. Why does repeated string concatenation create additional allocations?

In C#, strings are immutable. This means that the existing string cannot be modified directly.

When using:

```csharp
result += text;
```

a new string may be created containing the old content plus the new content.

As the loop continues, more string objects and copied characters can be generated, which increases memory allocations and execution time.

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` uses a mutable internal buffer.

Instead of creating a completely new string for every append operation, it can reuse its internal buffer and expand it when necessary.

This reduces the amount of repeated string creation and copying, making it generally more efficient for many append operations.

### 7. Is StringBuilder always better than normal string operations?

No.

For small amounts of text or a small number of concatenations, normal string operations using `+` are often simpler and can be fast enough.

`StringBuilder` becomes more useful when many strings are repeatedly appended, especially inside large loops.

## Conclusion

The benchmark demonstrates that repeated string concatenation becomes increasingly expensive as the number of iterations grows.

`StringBuilder` generally performs better for repeated text construction because it reduces the number of intermediate string allocations and copying operations.

The final conclusion is based on the BenchmarkDotNet results produced on the local machine.