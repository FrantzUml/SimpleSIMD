# SimpleSIMD

### What is SIMD?
Single Instruction, Multiple Data (SIMD) units refer to hardware components that perform the same operation on multiple data operands concurrently.
The concurrency is performed on a single thread, while utilizing the full size of the processor register to perform several operations at one.  
This approach could be combined with standard multithreading for massive performence boosts.

## Goals
This library Aims to simplify SIMD usage, and to make it easy to integrate it into an already existing solutions.  
It Replaces several LINQ functions which would benefit the most from using SIMD.  
Also, it Helps to generalize some methemathical functions for supported types.  
It Performs less allocations compared to standard LINQ implementations.   

## Available Functions
#### Comparison:
* Equal
* Greater
* GreaterEqual
* Less
* LessEqual

#### Elementwise:
* Abs
* Add
* Convert
* Div
* Mul
* Neg
* Select
* Sub

#### Reduction:
* Accumulate
* Avg
* Dot
* Max
* Min
* Sum

#### General Purpose:
* All
* Any
* Contains
* Copy
* Fill
* Foreach
* ToVector 

## Limitations
* Benefitial only for hardware which supports SIMD instructions
* Only work for collections of type ```Array```
* Could perform worse than simple for loop approach, for very small arrays
* Supports only **Primitive Numeric Types** as array elements. Supported types are:
  * ```byte, sbyte```
  * ```short, ushort```
  * ```int, uint```
  * ```long, ulong```
  * ```float```
  * ```double```

## License
This project is licensed under MIT license. For more info see the [License File](LICENSE)
