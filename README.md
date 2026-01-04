# External Merge Sort (C#)

A console-based implementation of an External Merge Sort algorithm, capable of sorting files that exceed physical memory limits.

## Overview
The application splits large files into sorted "runs," stores them on disk, and merges them into a final sorted output. It includes a random string generator for testing and a verification tool to ensure data integrity.

## Performance
| Items | Time | Memory |
| :--- | :--- | :--- |
| 1M | 1.3 s | 30 MB |
| 10M | 17 s | 105 MB |
| 100M | 3 m | 832 MB |

*Note: 1 Billion items take ~1 hour and require significant memory overhead.*

## Credits
Based on the work of Chris Hulbert (Splinter.com).
