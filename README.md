# External Merge Sort

This project demonstrates an external merge sort.  Create sorted runs.  Merge N sorted files.  

## Description

A console-mode demonstration of Merge Sorting files.  Split the input file into sorted run files.  Merge the sorted runs into the output file.  If the input file fits into memory, then use Internal Sort.  Otherwise use Merge Sort.  Creates a random file with random strings.  Use IsSorted() to check if the file is sorted.  

## Install and Build

The is a C# Console-Mode Project.  Open with  Visual Studio 2022 and above to compile. 

## Performance

Performance is good.

| Items | Run Size | Time | Memory |
| -- | -- | -- | -- |
| 10K | 1K | 26 ms | < 1MB |
| 100K | 10K | 142 ms | < 1 MB |
| 1M | 100K | 1.3 s | 30 MB |
| 10M | 1M | 17 s | 105 MB |
| 100M | 1M | 8 m | 105 MB |
| 100M | 10M | 3 m | 832 MB |

Performance is good up 100 million items.  At 1 billion items, memory is at 99% and CPU is 12%.  A run of one billion items would take one hour.


## References

   1. "Sorting enormous files using C# external merge sort", Chris Hulbert, Dec 2011, Splinter.com, github.com/chrishulbert/ExternalMergeSort
