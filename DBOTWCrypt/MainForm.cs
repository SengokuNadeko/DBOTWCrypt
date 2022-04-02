﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkUI.Forms;
using DarkUI.Controls;
using DarkUI.Icons;
namespace DBOTWCrypt
{
    public partial class MainForm : DarkForm
    {
        public List<byte> modifiedFileBytes = new List<byte>();
        public string filePath;
        public byte[] TheKey = new byte[] { 0x47, 0x9b, 0x11, 0xd5, 0xaa, 0x6f, 0x6a, 0x11, 0xba, 0xa2, 0x77, 0xd2, 0x5d, 0x79, 0x7d, 0xca, 0xb8, 0x92, 0xaa, 0x8a, 0x5e, 0xaa, 0xfe, 0x9b, 0x07, 0xac, 0x8c, 0x7c, 0x4b, 0xfe, 0x2a, 0xcb, 0x33, 0x9f, 0x8e, 0x54, 0xb2, 0xd4, 0x69, 0x2f, 0x46, 0xe4, 0x6f, 0x2b, 0xa7, 0xed, 0xf4, 0x3e, 0x80, 0x1d, 0xc8, 0x5f, 0xc2, 0x29, 0xd2, 0x2e, 0x9a, 0x14, 0x0b, 0x6f, 0x35, 0x76, 0xf8, 0x1d, 0x47, 0x3a, 0xc0, 0x29, 0x1a, 0x2f, 0x81, 0x6e, 0x76, 0x9e, 0xe6, 0x02, 0x19, 0x9e, 0x21, 0xad, 0xdb, 0x04, 0xc7, 0xc4, 0x14, 0x5a, 0xba, 0x05, 0x55, 0x61, 0x86, 0x51, 0x23, 0xa6, 0x0c, 0xa7, 0x08, 0xea, 0xe9, 0x5a, 0x2d, 0x21, 0xac, 0xaa, 0x63, 0x4c, 0x9e, 0x96, 0x30, 0x04, 0x00, 0x99, 0x8a, 0x5b, 0x03, 0xc7, 0x3f, 0xc0, 0xdc, 0x29, 0x37, 0x70, 0xda, 0x9b, 0xf6, 0x27, 0x1a, 0x31, 0x40, 0x8e, 0xce, 0x68, 0x1d, 0x10, 0x33, 0x64, 0x05, 0x10, 0x53, 0x35, 0xde, 0x5d, 0x9c, 0x7d, 0xdd, 0x98, 0x25, 0xc1, 0xb6, 0x72, 0x39, 0xf3, 0x38, 0xd3, 0x67, 0xb4, 0x8d, 0x61, 0x43, 0x30, 0xed, 0x63, 0x76, 0x8c, 0x80, 0x2c, 0xa2, 0xf8, 0x2e, 0xab, 0x5d, 0x77, 0x9b, 0xcb, 0xa1, 0xa3, 0xc5, 0xef, 0xbb, 0x90, 0x0f, 0x80, 0x2b, 0xb4, 0x93, 0xe9, 0x40, 0xff, 0xeb, 0x50, 0xad, 0x67, 0x1e, 0x1e, 0xd7, 0x8c, 0xb5, 0x86, 0x1c, 0x48, 0x1b, 0x51, 0xed, 0xb4, 0x03, 0xf7, 0x5c, 0xdb, 0x63, 0xc3, 0xd4, 0xbb, 0x48, 0xc6, 0x9b, 0x1b, 0x0f, 0x03, 0xb7, 0xf6, 0x93, 0x3f, 0x12, 0x41, 0xcc, 0xdd, 0x6f, 0x56, 0x7a, 0x81, 0x76, 0xfa, 0x4e, 0xfa, 0x6b, 0x4a, 0x94, 0x73, 0x45, 0x91, 0x72, 0xdf, 0x06, 0x0e, 0x29, 0x71, 0x92, 0xbf, 0x94, 0xa8, 0x0b, 0x7c, 0xf2, 0xab, 0x58, 0x50, 0x51, 0x86, 0x2b, 0xc7, 0x4f, 0x29, 0xcd, 0xc1, 0x6e, 0x16, 0x36, 0x24, 0x6b, 0x32, 0x0e, 0x44, 0xb4, 0x98, 0x6e, 0x09, 0xf4, 0x16, 0xf9, 0x6b, 0x06, 0x67, 0x2f, 0xa3, 0xef, 0x59, 0x96, 0x5c, 0x78, 0xba, 0x84, 0x63, 0x9b, 0x77, 0x0e, 0x35, 0x6c, 0x08, 0xcf, 0x66, 0xe0, 0xc7, 0x0a, 0x05, 0x43, 0x06, 0x64, 0x6f, 0x6a, 0xb3, 0xb7, 0x5b, 0x64, 0x34, 0xfc, 0x6d, 0x47, 0xdc, 0x8c, 0x80, 0xa8, 0x77, 0x33, 0x0f, 0xad, 0xeb, 0x91, 0x73, 0x0e, 0x21, 0xa7, 0x4c, 0x91, 0x29, 0x09, 0x32, 0x2a, 0xf5, 0xdc, 0x71, 0x13, 0x02, 0x12, 0xae, 0xce, 0x7d, 0xb5, 0x0c, 0x80, 0x9b, 0x72, 0xb4, 0x31, 0x72, 0x29, 0xd1, 0xc0, 0xb3, 0x8f, 0x33, 0x24, 0x1b, 0x5f, 0x57, 0x0c, 0xfc, 0xfb, 0x5c, 0x81, 0xcc, 0x3a, 0x5d, 0xfa, 0x59, 0xdb, 0xd8, 0xe8, 0x4d, 0xfa, 0xb1, 0x6d, 0x94, 0xea, 0x1d, 0x9b, 0x14, 0x5f, 0x0e, 0x20, 0x15, 0x8b, 0xfe, 0xb9, 0x35, 0x29, 0x50, 0x47, 0x80, 0x1a, 0xc8, 0x9c, 0x34, 0x13, 0xea, 0xc2, 0x5c, 0x5f, 0x99, 0x3a, 0x8c, 0xb2, 0x29, 0x09, 0xa6, 0xfd, 0x25, 0x57, 0x01, 0xd6, 0x16, 0xc0, 0xd2, 0x5c, 0x5e, 0x77, 0xef, 0xd5, 0xde, 0x3f, 0xd2, 0x07, 0x29, 0x29, 0x5e, 0xb4, 0x95, 0xae, 0x59, 0x60, 0x75, 0xfa, 0x29, 0x3a, 0x31, 0xb7, 0x9f, 0xc9, 0x0d, 0x20, 0xd3, 0xd5, 0x6f, 0x11, 0x45, 0xa3, 0x4d, 0xe3, 0xbb, 0x47, 0x66, 0x65, 0xb8, 0x62, 0xf9, 0x89, 0xdc, 0xc7, 0xec, 0xf5, 0x9b, 0x98, 0x74, 0xd2, 0x1a, 0x66, 0x8e, 0x0c, 0x34, 0xe8, 0x5f, 0x58, 0xa0, 0xce, 0xd9, 0x65, 0x3d, 0x0e, 0x60, 0x43, 0x00, 0x5f, 0x51, 0x76, 0x10, 0x49, 0x97, 0xcc, 0xc3, 0x92, 0xe6, 0xe0, 0xe5, 0xc2, 0x87, 0x47, 0xab, 0xbb, 0x36, 0x72, 0xc4, 0xa0, 0x38, 0xfa, 0xc7, 0x68, 0xef, 0xed, 0xca, 0xa0, 0x26, 0x68, 0xee, 0x04, 0xd0, 0x71, 0x33, 0x57, 0xc0, 0x68, 0x2d, 0xfd, 0x5b, 0x48, 0xfa, 0x2b, 0x5f, 0xbd, 0x35, 0x24, 0x6a, 0x7c, 0x9a, 0xd7, 0x95, 0x9f, 0x28, 0x53, 0xf8, 0xe3, 0xb0, 0xf1, 0xde, 0xab, 0x7f, 0xc6, 0xef, 0xcf, 0x75, 0x50, 0x86, 0x6e, 0xe7, 0xb2, 0x37, 0x5d, 0x31, 0xbf, 0x6b, 0xb8, 0x3f, 0xde, 0xeb, 0x3e, 0x1b, 0xb9, 0xd4, 0x9b, 0x6b, 0x8c, 0xc6, 0x7d, 0x5e, 0x81, 0x8e, 0x7c, 0xe9, 0x36, 0x03, 0xd3, 0x50, 0x7e, 0x5f, 0x7b, 0xf6, 0x0a, 0x3c, 0xad, 0x12, 0xf9, 0x6c, 0x3c, 0x14, 0x2b, 0x50, 0xfd, 0xa4, 0x8d, 0xab, 0x0b, 0xba, 0xed, 0xad, 0x32, 0x6c, 0xa5, 0x79, 0xa3, 0x5b, 0xc7, 0xb9, 0xde, 0xfc, 0xee, 0xaa, 0x25, 0x40, 0xda, 0x9f, 0x7a, 0x1a, 0xd2, 0x82, 0x0a, 0x93, 0xfe, 0xc5, 0x1f, 0x95, 0xd7, 0x26, 0xf1, 0x5c, 0xd2, 0x1a, 0xa3, 0x49, 0x4a, 0x5f, 0xe7, 0x00, 0x87, 0x8d, 0x70, 0xd3, 0x22, 0xfa, 0x7f, 0x9c, 0x86, 0x37, 0x37, 0xa5, 0x9f, 0x62, 0x47, 0x7a, 0x3e, 0x6c, 0x0f, 0xcb, 0x7c, 0xea, 0x77, 0xc5, 0xf4, 0x6f, 0xa0, 0xa3, 0x81, 0x09, 0x50, 0x7f, 0x51, 0x6a, 0x09, 0x3f, 0xba, 0xbc, 0xfc, 0x3c, 0x9f, 0x3b, 0x2c, 0x61, 0x9f, 0x99, 0x60, 0x26, 0x60, 0x1f, 0x30, 0x43, 0x5f, 0x5f, 0xf3, 0xed, 0xbe, 0x9b, 0xdb, 0x4b, 0x1a, 0x70, 0x15, 0x6b, 0x09, 0x0b, 0x23, 0xd2, 0x80, 0x47, 0xdd, 0x6a, 0x71, 0x86, 0xa2, 0xbd, 0x72, 0xc6, 0xe1, 0xb5, 0xa6, 0x6b, 0x00, 0xa6, 0x57, 0x8f, 0xbf, 0x16, 0xb8, 0xe8, 0x3a, 0x55, 0x90, 0xae, 0x34, 0xaf, 0x9e, 0x08, 0xb7, 0xd8, 0xd5, 0xbf, 0x04, 0x39, 0x0b, 0x88, 0x0a, 0x05, 0x57, 0x5f, 0x8e, 0x2b, 0xa4, 0x8d, 0x95, 0x64, 0x22, 0x43, 0x75, 0xda, 0x6e, 0x34, 0xf2, 0xe2, 0xf3, 0x68, 0xea, 0x4a, 0x73, 0xee, 0x63, 0xcb, 0x46, 0xc1, 0x80, 0x3b, 0xb8, 0x18, 0x62, 0xe4, 0x53, 0x40, 0xb3, 0xbe, 0xde, 0xc0, 0x66, 0xb7, 0x16, 0xc1, 0x2d, 0xcd, 0x47, 0x8b, 0x8f, 0x12, 0x74, 0xdc, 0xed, 0xee, 0x5b, 0xf0, 0x15, 0x47, 0x50, 0x5f, 0x32, 0x69, 0x5c, 0x02, 0x00, 0x3d, 0x09, 0xb1, 0x51, 0x28, 0x87, 0x28, 0xb1, 0x0b, 0xc6, 0xb1, 0x26, 0x70, 0x85, 0xc9, 0xe2, 0x6e, 0x4a, 0xea, 0x4b, 0xca, 0xb7, 0x41, 0xc7, 0xf9, 0x60, 0xaa, 0xcf, 0xad, 0xcb, 0xe1, 0x08, 0xd0, 0x8d, 0xfa, 0x0e, 0x84, 0x82, 0xd5, 0x28, 0x5f, 0x29, 0xdd, 0xd6, 0x44, 0xdb, 0xb5, 0xba, 0x4f, 0x53, 0x5f, 0x53, 0x22, 0x86, 0x28, 0x29, 0x17, 0x7f, 0x79, 0x21, 0xc7, 0x85, 0x69, 0xda, 0x0e, 0x94, 0x32, 0xed, 0x8d, 0x37, 0x2e, 0xa0, 0x34, 0x47, 0x4a, 0x66, 0x82, 0x69, 0x46, 0x2d, 0x39, 0xe7, 0x79, 0xbf, 0x8c, 0x57, 0x65, 0x6f, 0x41, 0xc3, 0x76, 0x0c, 0xfd, 0x18, 0x15, 0x9d, 0x3a, 0xac, 0x1b, 0x44, 0x48, 0x8d, 0xfc, 0xff, 0xf4, 0x52, 0x5f, 0xaf, 0xb2, 0x71, 0x7d, 0x0c, 0x3c, 0xa1, 0x86, 0x71, 0xce, 0x52, 0xb0, 0x05, 0xeb, 0xd7, 0x63, 0x18, 0x53, 0x59, 0x11, 0xdb, 0x81, 0x19, 0x1d, 0xfb, 0x4d, 0x91, 0xa9, 0x24, 0x88, 0xe2, 0x7e, 0x6e, 0xdf, 0xc1, 0x2c, 0x66, 0x79, 0x25, 0x06, 0x99, 0x4c, 0x9a, 0x10, 0xb8, 0xf5, 0x8c, 0x69, 0xe7, 0x6b, 0x56, 0xfd, 0x6f, 0x07, 0x52, 0x5f, 0x4a, 0xd1, 0x47, 0x42, 0x35, 0xa6, 0xc8, 0xd3, 0x44, 0x1d, 0x88, 0xc7, 0x25, 0x11, 0x54, 0x7a, 0x12, 0xeb, 0x87, 0xa3, 0x8a, 0xc6, 0xad, 0x58, 0xdf, 0x04, 0x31, 0x60, 0x18, 0x28, 0x27, 0xe0, 0x57, 0x89, 0x5d, 0xb3, 0x03, 0xb5, 0xa5, 0x72, 0x17, 0x07, 0x74, 0x47, 0x2f, 0x78, 0xa5, 0xde, 0xf2, 0xf4, 0xe8, 0xfd, 0xdd, 0x6a, 0x52, 0x5f, 0x06, 0x0d, 0x05, 0x9a, 0x6c, 0xfa, 0xd4, 0x77, 0x00, 0xfc, 0x05, 0x50, 0x97, 0xa1, 0x17, 0x07, 0xf1, 0x94, 0xfd, 0xd5, 0x70, 0x56, 0x23, 0x89, 0x87, 0x8b, 0x13, 0xea, 0xb4, 0xb2, 0xf4, 0x72, 0xf1, 0x31, 0x4d, 0x3e, 0x73, 0xf7, 0x7d, 0x09, 0x7a, 0x86, 0x9c, 0xa6, 0x86, 0xf5, 0x2a, 0x3b, 0x83, 0x4d, 0x42, 0x32, 0x8b, 0x50, 0x52, 0x5f, 0x5a, 0xcb, 0x35, 0x7e, 0x8f, 0x10, 0x68, 0x69, 0x89, 0xca, 0xa8, 0x65, 0x72, 0xd6, 0xa3, 0x95, 0xbb, 0xe9, 0x89, 0x36, 0x4a, 0xeb, 0xc2, 0x6e, 0xf3, 0xcd, 0x74, 0xcf, 0x0e, 0xc2, 0x0c, 0x9d, 0x94, 0x7a, 0x77, 0x92, 0x8c, 0xe6, 0xeb, 0xdc, 0x09, 0xe9, 0xaa, 0xd5, 0x9b, 0x69, 0x38, 0xd3, 0x49, 0x66, 0x37, 0xde, 0x17, 0x45, 0x52, 0x5f, 0xe0, 0x1a, 0xd6, 0x75, 0x39, 0x6f, 0xa8, 0x51, 0x44, 0xe0, 0x81, 0x89, 0x0e, 0xe1, 0xf6, 0x22, 0x4f, 0x57, 0xb5, 0x42, 0x27, 0x49, 0x43, 0x15, 0x11, 0x9f, 0x1e, 0x60, 0xd4, 0xc0, 0xa1, 0xb0, 0xaf, 0xdb, 0xb2, 0x1c, 0x6e, 0x84, 0x3f, 0x75, 0xdc, 0x25, 0xea, 0x6d, 0x1e, 0xa2, 0xe8, 0x25, 0x9a, 0xeb, 0x3b, 0xe3, 0x07, 0x48, 0x52, 0x5f, 0x82, 0x14, 0x8d, 0x50, 0x3e, 0x87, 0x97, 0xa3, 0x49, 0x92, 0xa1, 0x79, 0x12, 0xbc, 0xca, 0x1b, 0x91, 0xe7, 0x1c, 0x45, 0xf7, 0x86, 0xca, 0xb6, 0x28, 0x88, 0x4f, 0xa3, 0xd1, 0x60, 0xa9, 0xde, 0x6d, 0xa0, 0x41, 0x14, 0xec, 0xab, 0x8d, 0x9d, 0x5c, 0x84, 0xe3, 0x0f, 0xbd, 0x6a, 0x4d, 0x43, 0xf0, 0x88, 0x26, 0x73, 0xd6, 0x4c, 0x52, 0x5f, 0xe9, 0xf3, 0x41, 0x8e, 0x10, 0xda, 0x1c, 0x08, 0xed, 0x5d, 0x24, 0xb6, 0x21, 0x28, 0xa3, 0x53, 0xa6, 0x17, 0xc3, 0xa2, 0x1b, 0x85, 0x6a, 0x88, 0x88, 0x5b, 0x53, 0x13, 0x9e, 0x1e, 0x91, 0x09, 0xc9, 0x4f, 0xf2, 0xd4, 0xb1, 0x43, 0xb1, 0x50, 0xeb, 0x75, 0x59, 0x59, 0x7d, 0x1c, 0x4b, 0x26, 0xbb, 0xa7, 0x0e, 0x57, 0x4b, 0x4e, 0x52, 0x5f, 0x3b, 0x03, 0xe2, 0x46, 0x46, 0x1d, 0x77, 0x2c, 0x2c, 0x9e, 0xf5, 0xae, 0xe1, 0x95, 0x2d, 0x47, 0x06, 0xef, 0x1d, 0xac, 0x32, 0x0e, 0xc5, 0x4d, 0x18, 0x3e, 0xe3, 0x46, 0x39, 0x47, 0xa4, 0xbe, 0x67, 0x37, 0xf5, 0x6a, 0x11, 0x5d, 0x0a, 0x5f, 0x7c, 0x5a, 0xd2, 0x9b, 0x3a, 0xe5, 0x8f, 0x48, 0xee, 0xfc, 0x34, 0xc7, 0x88, 0x4f, 0x52, 0x5f, 0x6b, 0x67, 0xc4, 0x3f, 0xb7, 0xc2, 0xfd, 0xf9, 0x44, 0x8e, 0x73, 0x96, 0x32, 0x15, 0x33, 0xdb, 0x06, 0x4c, 0x98, 0xa0, 0xb2, 0x5f, 0x58, 0x18, 0x4c, 0x0c, 0x17, 0xbe, 0xec, 0x43, 0x4d, 0x6b, 0x65, 0x5b, 0x40, 0xbb, 0xa2, 0xf3, 0x2f, 0xbb, 0x53, 0xa4, 0x18, 0x71, 0xc8, 0x50, 0xd4, 0x9e, 0x89, 0x6a, 0x3d, 0x87, 0x1d, 0x4f, 0x52, 0x5f, 0x3a, 0x1a, 0xc1, 0x50, 0x71, 0x04, 0xfd, 0xea, 0x3e, 0xc4, 0x75, 0x02, 0xec, 0x63, 0x27, 0xda, 0x34, 0xcc, 0x6b, 0x07, 0xdd, 0x9d, 0x1d, 0x3f, 0x51, 0x3e, 0xe5, 0xf6, 0x48, 0xb4, 0x07, 0xee, 0x4e, 0x9f, 0xb6, 0xdd, 0x4b, 0x9f, 0x7b, 0x2b, 0x8e, 0x3b, 0x5b, 0xe4, 0x81, 0x62, 0x31, 0x10, 0xb4, 0xea, 0x53, 0x04, 0x6c, 0x4f, 0x52, 0x5f, 0xde, 0x0b, 0xd6, 0x04, 0xa2, 0xa5, 0x63, 0x17, 0x2c, 0x14, 0x72, 0x33, 0xa0, 0x24, 0xd0, 0xed, 0xff, 0xa9, 0x64, 0xb5, 0x12, 0x16, 0x2d, 0xd9, 0xdc, 0x82, 0x3b, 0x37, 0x8f, 0xa9, 0x32, 0x6d, 0xff, 0xd4, 0x82, 0xb3, 0xe1, 0xaf, 0xb0, 0x80, 0x81, 0x9c, 0x0c, 0x5f, 0x75, 0x34, 0x74, 0x20, 0x29, 0x82, 0x7c, 0xcb, 0x5e, 0x4f, 0x52, 0x5f, 0x6b, 0xcf, 0x42, 0xef, 0xfc, 0x0b, 0x46, 0x30, 0xa5, 0x93, 0xe9, 0xa3, 0xc9, 0x6e, 0xa0, 0xd4, 0xb8, 0x78, 0xf2, 0x4b, 0xd5, 0x81, 0x70, 0x25, 0x7e, 0x94, 0xe2, 0x42, 0xdd, 0xdb, 0x02, 0x56, 0xd8, 0xcf, 0xc5, 0x27, 0x1f, 0xdf, 0x59, 0x4e, 0xe1, 0x77, 0xd3, 0x78, 0x5b, 0x56, 0xda, 0x60, 0x26, 0xa1, 0x9f, 0x69, 0x49, 0x4f, 0x52, 0x5f, 0xc7, 0x8c, 0xc7, 0x05, 0xfc, 0xd3, 0x4e, 0x32, 0x39, 0x3d, 0xca, 0x3b, 0x96, 0x8a, 0x3d, 0xba, 0x5a, 0x65, 0xba, 0x58, 0x44, 0x3c, 0x92, 0x01, 0xc0, 0xf8, 0xdf, 0x3b, 0xd3, 0x80, 0xd0, 0xca, 0x4a, 0xae, 0x4c, 0xdb, 0x92, 0xa4, 0xb6, 0x43, 0x80, 0x61, 0x60, 0xf4, 0x0e, 0x98, 0xa3, 0x18, 0x8b, 0x3d, 0x75, 0x8b, 0x40, 0x4f, 0x52, 0x5f, 0xe0, 0x5e, 0xb8, 0xfb, 0x18, 0xbf, 0x58, 0x1c, 0x75, 0x86, 0x8a, 0xe5, 0x27, 0xdf, 0x82, 0x49, 0x7a, 0xda, 0x9e, 0x2c, 0xbc, 0xdd, 0xbb, 0x17, 0x13, 0xf5, 0x44, 0xd7, 0x72, 0x4f, 0x54, 0x9a, 0x29, 0x22, 0xca, 0x8c, 0x59, 0xe7, 0x2d, 0x30, 0xea, 0x68, 0x1e, 0x9b, 0xab, 0x3e, 0x61, 0xe3, 0x99, 0xb0, 0x46, 0x4b, 0x45, 0x4f, 0x52, 0x5f, 0xf7, 0x94, 0xa4, 0x72, 0xd0, 0x07, 0xe0, 0x6b, 0x7b, 0x98, 0xaa, 0x26, 0x77, 0xbe, 0x67, 0xff, 0x75, 0x57, 0xa3, 0x67, 0xa8, 0x1b, 0xcd, 0x98, 0xf7, 0x08, 0xea, 0x0f, 0xd3, 0xd1, 0x1d, 0x39, 0xea, 0x05, 0xdc, 0xc4, 0x1e, 0x60, 0x50, 0xe6, 0x05, 0xea, 0x76, 0x56, 0x60, 0x38, 0x3f, 0x65, 0x64, 0x08, 0x9a, 0x8d, 0x47, 0x4f, 0x52, 0x5f, 0xb8, 0x45, 0x8a, 0xd3, 0xb5, 0xbe, 0xd0, 0x82, 0x23, 0x51, 0x89, 0x95, 0x23, 0x40, 0x29, 0x75, 0x7b, 0x73, 0xdf, 0xd2, 0xfa, 0xbd, 0x1f, 0xf2, 0x40, 0x0c, 0x1f, 0x11, 0x22, 0x3a, 0xe5, 0x10, 0x9c, 0xc4, 0x41, 0x3a, 0x42, 0x27, 0x6e, 0x51, 0x7a, 0xbc, 0xab, 0x57, 0x5b, 0x60, 0x80, 0xaa, 0x3b, 0xf0, 0xaf, 0x86, 0x46, 0x4f, 0x52, 0x5f, 0xb8, 0xeb, 0xde, 0xbb, 0xe7, 0x18, 0x02, 0x2f, 0x6b, 0x17, 0x4c, 0x0d, 0x2d, 0x54, 0xca, 0xa2, 0x05, 0x20, 0x08, 0xb2, 0x0c, 0xe0, 0xa6, 0xf8, 0x9d, 0xf1, 0x1d, 0x3c, 0x6a, 0x76, 0xa3, 0x7b, 0xb8, 0xcc, 0xdc, 0x4b, 0x3b, 0x5b, 0x75, 0x6c, 0x0e, 0x9a, 0xf2, 0x0a, 0x80, 0x22, 0xd3, 0x3f, 0xdf, 0x09, 0x51, 0x2d, 0x46, 0x4f, 0x52, 0x5f, 0x4a, 0xf1, 0x84, 0xd3, 0xbc, 0x6d, 0x81, 0xfa, 0xc4, 0x20, 0x8f, 0xb9, 0x32, 0x4c, 0x2e, 0x69, 0xe8, 0x15, 0xf3, 0x4f, 0xa1, 0x5e, 0x73, 0xea, 0x3b, 0xe5, 0x2d, 0x30, 0xaa, 0x88, 0x78, 0xea, 0x04, 0x85, 0x91, 0x4c, 0xc6, 0xbe, 0x7c, 0x2e, 0x9f, 0xaf, 0x3d, 0xaa, 0x13, 0x90, 0xb1, 0x2d, 0x4e, 0x6d, 0x5d, 0x69, 0x46, 0x4f, 0x52, 0x5f, 0x57, 0x99, 0x33, 0x11, 0x68, 0x77, 0x12, 0x83, 0xd6, 0xbb, 0x50, 0xc2, 0x89, 0x57, 0x11, 0xb6, 0x96, 0xf8, 0x7f, 0x8e, 0x95, 0x95, 0x2c, 0xe5, 0x6e, 0x2e, 0x3f, 0xca, 0x01, 0x42, 0x22, 0xe3, 0x95, 0x53, 0xdc, 0xeb, 0x75, 0xf7, 0x73, 0xa7, 0x5a, 0xce, 0x72, 0x8d, 0x7a, 0xc2, 0x64, 0x0d, 0xf5, 0x2c, 0x13, 0x40, 0x46, 0x4f, 0x52, 0x5f, 0xa5, 0x82, 0x8a, 0x34, 0x52, 0xa0, 0x5e, 0xe4, 0x35, 0x27, 0xed, 0x91, 0x4b, 0x85, 0x5e, 0x68, 0x9b, 0x0e, 0xd7, 0xcf, 0xb9, 0x6e, 0xf1, 0x7e, 0x80, 0xa5, 0xc6, 0xc9, 0xe4, 0x0d, 0xd0, 0xb1, 0xba, 0x9d, 0x9a, 0xe9, 0x90, 0xfa, 0x42, 0x36, 0x7d, 0x15, 0x3a, 0x70, 0xf8, 0xc9, 0x0a, 0x3b, 0x95, 0x36, 0x66, 0x50, 0x46, 0x4f, 0x52, 0x5f, 0xa6, 0x4e, 0xd9, 0xda, 0x08, 0x40, 0x2f, 0x92, 0x65, 0x41, 0x83, 0xcc, 0xe8, 0x15, 0x78, 0xd6, 0x6b, 0x80, 0x37, 0x44, 0xc8, 0xeb, 0x6c, 0x7c, 0x21, 0x7a, 0xee, 0x67, 0x56, 0x8a, 0xe2, 0x30, 0xb0, 0xfa, 0x3e, 0x78, 0x31, 0x78, 0xed, 0x24, 0x1d, 0x63, 0xfb, 0x11, 0x2f, 0x95, 0x1b, 0xb1, 0x46, 0xb7, 0xdf, 0x59, 0x46, 0x4f, 0x52, 0x5f, 0x95, 0x7b, 0xab, 0x1e, 0xe9, 0xc9, 0xab, 0xfb, 0xbb, 0x79, 0x7c, 0x77, 0xa7, 0x86, 0x70, 0x52, 0x33, 0xa3, 0x52, 0x7f, 0xf6, 0xd8, 0xa6, 0x78, 0x56, 0x6e, 0xdd, 0xf6, 0x26, 0x91, 0x5c, 0xda, 0x8d, 0x98, 0x51, 0x6a, 0x8b, 0x00, 0x28, 0x1f, 0xe1, 0x5c, 0x9f, 0xa3, 0xb0, 0x22, 0x67, 0xf4, 0x12, 0xe3, 0x3f, 0x5c, 0x46, 0x4f, 0x52, 0x5f, 0xbe, 0xde, 0x7b, 0x5e, 0xa5, 0x2e, 0xe5, 0xfb, 0xaa, 0x0b, 0x02, 0xf4, 0xe8, 0x2e, 0x5a, 0xde, 0xe0, 0x1b, 0xb1, 0x5c, 0x3c, 0x15, 0xe4, 0xcd, 0x09, 0x7b, 0x14, 0x19, 0x4b, 0x84, 0xb2, 0xd8, 0x10, 0x42, 0xda, 0x93, 0xf5, 0x41, 0xd5, 0x3d, 0x8d, 0x6d, 0x51, 0xb9, 0x34, 0xad, 0x10, 0x7f, 0xdd, 0x36, 0x8b, 0x5e, 0x46, 0x4f, 0x52, 0x5f, 0x71, 0x2d, 0x06, 0xfe, 0xed, 0xbf, 0xa9, 0x41, 0x4d, 0x3e, 0xb4, 0xdb, 0x4d, 0xd3, 0xc9, 0x05, 0x42, 0x13, 0xf2, 0x4f, 0xd2, 0x6e, 0xc3, 0xe3, 0x26, 0x55, 0x2d, 0xa4, 0x25, 0x2a, 0x10, 0x7f, 0xb6, 0xc1, 0x61, 0x67, 0x81, 0xef, 0xff, 0xea, 0x15, 0x3e, 0x9e, 0xa3, 0x4f, 0x63, 0x26, 0xa2, 0x60, 0x6b, 0xbf, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xee, 0x82, 0x4b, 0xce, 0xcd, 0xdb, 0x24, 0xab, 0xe2, 0x94, 0x20, 0xb9, 0xeb, 0x08, 0x10, 0x66, 0x73, 0xa8, 0x45, 0x5c, 0xea, 0xf8, 0x13, 0x2b, 0xcf, 0xb1, 0x7e, 0x71, 0x55, 0xbb, 0xf1, 0xa3, 0x9f, 0x4b, 0x04, 0x5b, 0xc3, 0x71, 0x0c, 0xc0, 0xff, 0x60, 0x49, 0xde, 0x95, 0xa3, 0x37, 0x7b, 0xf0, 0x6e, 0x1e, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xc0, 0x4c, 0x95, 0x4b, 0x3e, 0x78, 0xde, 0xa3, 0x3a, 0x10, 0xdb, 0x76, 0xd6, 0xfe, 0x1c, 0x3c, 0xc6, 0xf8, 0xad, 0x73, 0xe7, 0x3c, 0xd3, 0x87, 0xb6, 0x89, 0xe3, 0x7d, 0x9d, 0xcc, 0x54, 0x87, 0x74, 0x8f, 0xfe, 0xc3, 0x17, 0xbf, 0xf1, 0xe0, 0xa9, 0x50, 0x7a, 0x79, 0x21, 0x73, 0xd8, 0xb6, 0x95, 0xe7, 0x66, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x2b, 0x30, 0x75, 0x53, 0x4d, 0xe5, 0xe3, 0xe3, 0x4c, 0x59, 0x18, 0xec, 0xc5, 0xf7, 0xf9, 0xb4, 0xd8, 0xfa, 0x1e, 0xce, 0xc1, 0xc5, 0x2d, 0x2c, 0xdc, 0x1c, 0x05, 0xe9, 0xe4, 0x29, 0xf1, 0xb4, 0xf6, 0xf7, 0x91, 0xff, 0x20, 0x22, 0x28, 0x64, 0xd0, 0x60, 0x56, 0xc7, 0x1c, 0xca, 0x6c, 0x32, 0x1e, 0xd5, 0x4f, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xae, 0x3f, 0xd5, 0x8d, 0x1d, 0xef, 0xd5, 0x05, 0x92, 0xdf, 0x5f, 0x54, 0x1a, 0x1b, 0xcf, 0x6f, 0x08, 0xbb, 0xee, 0x34, 0x69, 0xb6, 0xb8, 0x69, 0xee, 0x70, 0xd5, 0x65, 0xc5, 0xa5, 0xdd, 0xbd, 0x3a, 0x0a, 0x40, 0x6d, 0x66, 0x53, 0x15, 0x31, 0xfe, 0x7c, 0x8f, 0x3c, 0xc0, 0x58, 0xca, 0x5f, 0x9e, 0xca, 0x50, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x4d, 0xb6, 0xa1, 0xbf, 0xc4, 0x4f, 0x99, 0xf8, 0x22, 0xf3, 0xb4, 0x5b, 0xe1, 0x04, 0x47, 0x0c, 0x9c, 0x61, 0xf2, 0x39, 0x41, 0x24, 0x4f, 0x5d, 0x86, 0x65, 0xc5, 0x7d, 0x71, 0x52, 0x39, 0x42, 0x47, 0xc3, 0x14, 0xec, 0x7b, 0x88, 0xb0, 0x4f, 0x1a, 0x03, 0xe6, 0xb9, 0xb8, 0xde, 0x0f, 0x94, 0xc4, 0x51, 0x5f, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xe5, 0x34, 0x43, 0x4f, 0x28, 0x8e, 0x05, 0xa0, 0xf0, 0xb3, 0x96, 0xe3, 0x36, 0xe1, 0xb2, 0x89, 0x1c, 0x55, 0xc5, 0x5c, 0xc0, 0x86, 0xa6, 0x06, 0x50, 0xde, 0xd8, 0xf6, 0xcf, 0xb0, 0xd4, 0x09, 0x31, 0xa0, 0x53, 0xc6, 0xde, 0x89, 0x9f, 0x70, 0x7c, 0xdc, 0xb1, 0xa8, 0x46, 0xda, 0x24, 0x58, 0x47, 0x0d, 0x5a, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xd3, 0xcf, 0x77, 0x8e, 0x25, 0xa2, 0xfa, 0xf2, 0x1a, 0x50, 0xc5, 0x75, 0xe1, 0xcb, 0x7b, 0xd7, 0xd0, 0x23, 0x8b, 0x29, 0xc5, 0x47, 0x21, 0x77, 0xcb, 0xdb, 0x31, 0xb9, 0x81, 0xde, 0x7d, 0xff, 0xe4, 0xf1, 0xb1, 0xdb, 0x43, 0x19, 0x3d, 0xa7, 0x72, 0xe3, 0x0f, 0x78, 0x2c, 0x6f, 0x4e, 0xa1, 0x84, 0x9e, 0x58, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x4d, 0xfb, 0xbc, 0x40, 0xc2, 0x1e, 0xe0, 0xdc, 0x3f, 0x04, 0x7c, 0x9d, 0x6e, 0xb0, 0xc3, 0x88, 0xcb, 0x6a, 0xd5, 0x34, 0x6e, 0x52, 0x24, 0x22, 0xe9, 0x05, 0xcc, 0x81, 0x89, 0xab, 0xc3, 0x8e, 0x05, 0x2a, 0xfe, 0x5c, 0x7a, 0x5d, 0x8c, 0xe9, 0x65, 0x1d, 0x3e, 0xb1, 0xfb, 0xb2, 0x3d, 0x50, 0xfb, 0xfc, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x62, 0xf7, 0xfb, 0xfc, 0xbb, 0x04, 0xee, 0xfe, 0x81, 0x18, 0xbc, 0xb2, 0x9d, 0x77, 0x22, 0xa4, 0x18, 0x99, 0x5b, 0xb0, 0xe3, 0x17, 0x68, 0x6b, 0x03, 0xa4, 0xa3, 0xc6, 0xab, 0x2a, 0xc4, 0x6c, 0x50, 0x61, 0x26, 0x6b, 0x21, 0xe0, 0x68, 0x84, 0xf5, 0x95, 0xe1, 0x24, 0x84, 0x41, 0xc0, 0x1e, 0xc9, 0x24, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xde, 0x0d, 0x29, 0x96, 0xc9, 0xbb, 0x2f, 0xe9, 0x85, 0xd3, 0x44, 0xab, 0x96, 0x79, 0x8c, 0x63, 0xaf, 0x37, 0xda, 0xf5, 0x2f, 0xa6, 0xc5, 0x0a, 0x0d, 0x5e, 0x79, 0xb8, 0xd5, 0xf2, 0xbf, 0xd2, 0xef, 0x35, 0x2b, 0x2b, 0x49, 0x90, 0x2a, 0xb1, 0xb8, 0xac, 0x19, 0xe8, 0x04, 0xe8, 0xd1, 0x1d, 0x8e, 0x7c, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xd0, 0x72, 0x41, 0xf4, 0x0b, 0x89, 0x54, 0x0c, 0x46, 0xfb, 0x63, 0xf7, 0x3a, 0x6e, 0xba, 0x9a, 0xc5, 0xbf, 0xa0, 0xfa, 0xbc, 0xb9, 0x48, 0xac, 0x53, 0xba, 0x37, 0x55, 0x3d, 0xe3, 0xc9, 0x96, 0x80, 0x63, 0x62, 0x50, 0x5c, 0x8c, 0x28, 0xd7, 0x13, 0x5b, 0xc4, 0x61, 0x62, 0x7c, 0x07, 0xef, 0x61, 0x54, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xd4, 0x23, 0x7a, 0xeb, 0x9f, 0xfc, 0xbe, 0x23, 0xc8, 0xd7, 0x3e, 0xf5, 0x56, 0xda, 0xd9, 0xbd, 0xb5, 0x72, 0xe7, 0x2b, 0xf1, 0xab, 0x17, 0xf9, 0x80, 0x2c, 0x94, 0x37, 0x4e, 0xad, 0x54, 0xeb, 0x97, 0x66, 0x34, 0x00, 0xa4, 0x7a, 0xde, 0x3a, 0x98, 0xce, 0xdf, 0x99, 0xe7, 0xff, 0xf0, 0x3f, 0x81, 0x48, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xf8, 0xcc, 0x22, 0x0a, 0xeb, 0x36, 0xe9, 0xd8, 0x23, 0x12, 0x2f, 0x19, 0x62, 0x70, 0x09, 0x56, 0xaf, 0x89, 0x3c, 0xc0, 0x96, 0x20, 0xa2, 0x15, 0x84, 0x34, 0xda, 0x34, 0x3c, 0x33, 0xc2, 0x40, 0x34, 0xa0, 0xca, 0xd9, 0x9c, 0xb9, 0x44, 0x69, 0x81, 0xcf, 0x5d, 0x3d, 0x2b, 0xb3, 0xb2, 0xf5, 0x3c, 0x40, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x1a, 0x84, 0xa3, 0x4b, 0xf9, 0xcf, 0xf6, 0x62, 0x21, 0x77, 0x3a, 0x6d, 0x04, 0x59, 0x43, 0x8e, 0xad, 0xf2, 0x45, 0xdb, 0x03, 0x34, 0x2a, 0xf6, 0x8f, 0x92, 0x9a, 0x87, 0x9c, 0x5a, 0xca, 0x25, 0xe6, 0x13, 0x72, 0xe3, 0x80, 0x19, 0xbd, 0x45, 0x94, 0xaa, 0xa4, 0xb4, 0x58, 0x6f, 0xf0, 0x14, 0xc9, 0x46, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x7f, 0xed, 0x2b, 0x2a, 0x41, 0x35, 0x84, 0x2e, 0x4b, 0xd7, 0x55, 0x77, 0xfd, 0xed, 0x23, 0x6e, 0x13, 0xb9, 0x41, 0x47, 0xe1, 0x0d, 0x6f, 0x1d, 0x78, 0x8a, 0xf7, 0x35, 0x6d, 0xc1, 0xd0, 0xaa, 0x2d, 0x81, 0x68, 0x55, 0x9c, 0x88, 0x36, 0x51, 0xbd, 0x3e, 0x43, 0x9c, 0xd8, 0x76, 0xa2, 0x4e, 0x2a, 0x44, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x56, 0x58, 0x33, 0x72, 0x54, 0x88, 0xd2, 0x4f, 0x64, 0xce, 0x04, 0xe9, 0x57, 0x39, 0x34, 0x50, 0x11, 0x3b, 0x91, 0x6b, 0x5a, 0x55, 0xef, 0x2d, 0x1e, 0xed, 0x59, 0x2f, 0x72, 0xe3, 0x36, 0x60, 0x8e, 0xf0, 0xe6, 0x1e, 0x76, 0x48, 0xae, 0x38, 0x01, 0x38, 0x57, 0x33, 0xbf, 0xa3, 0xa6, 0xd2, 0xbf, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x0e, 0x87, 0xfd, 0x8e, 0x9b, 0x6a, 0x7d, 0xee, 0x02, 0x81, 0x67, 0x02, 0x3c, 0x5f, 0xb1, 0xc8, 0x53, 0x45, 0x9e, 0x38, 0xb3, 0xef, 0x14, 0x1d, 0x45, 0xa1, 0xb4, 0x5a, 0xac, 0xa8, 0x1a, 0x45, 0xfd, 0xb8, 0x41, 0x25, 0xba, 0xb0, 0xbc, 0xb8, 0xaf, 0x8a, 0xef, 0x85, 0x12, 0x96, 0xac, 0x70, 0x10, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xf5, 0x46, 0x52, 0xbf, 0x99, 0xcf, 0xb7, 0x19, 0xdc, 0xf0, 0x22, 0x78, 0xc1, 0xea, 0x64, 0x18, 0x26, 0x08, 0xf7, 0x51, 0x1f, 0x15, 0x57, 0x13, 0x6a, 0x26, 0x27, 0xb5, 0x5c, 0x10, 0x00, 0x47, 0xf6, 0x09, 0xe9, 0x00, 0xf2, 0xc9, 0xd4, 0x0d, 0x59, 0xd1, 0x59, 0x0e, 0xa8, 0x42, 0x50, 0x92, 0x70, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xdc, 0x67, 0x6d, 0x0f, 0x0d, 0x56, 0x9d, 0x9b, 0x02, 0x22, 0x79, 0x33, 0x7d, 0xc5, 0x11, 0xfb, 0x06, 0x03, 0x9f, 0x96, 0x58, 0xc6, 0x30, 0x0e, 0xc8, 0x3d, 0xfc, 0xd8, 0x98, 0x0b, 0x1a, 0xac, 0xcc, 0x72, 0x0f, 0xf2, 0xf1, 0xfe, 0x10, 0x2d, 0x4b, 0x33, 0xe1, 0x4c, 0xf2, 0x6c, 0x58, 0xdc, 0x53, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xb0, 0x59, 0xaa, 0xcd, 0x73, 0x40, 0x9d, 0x59, 0x49, 0xdd, 0x68, 0xcf, 0x22, 0x32, 0x76, 0x77, 0x15, 0x1e, 0x7b, 0x42, 0x22, 0xc9, 0xa6, 0x44, 0xe1, 0x7e, 0x92, 0xe3, 0x29, 0x65, 0xb3, 0xd7, 0x0b, 0xe8, 0xc7, 0x18, 0x02, 0x6e, 0xae, 0xfc, 0xfa, 0xfa, 0xe9, 0x40, 0xa4, 0x49, 0x69, 0x51, 0x45, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x1b, 0x80, 0x8b, 0x51, 0x6c, 0x6c, 0xda, 0x14, 0xef, 0x95, 0x11, 0x21, 0xff, 0x38, 0xba, 0xc7, 0x39, 0x5b, 0xf8, 0x04, 0x5c, 0x62, 0x6b, 0xd0, 0x72, 0x84, 0x9d, 0x44, 0x2a, 0xcd, 0x31, 0x20, 0xe1, 0x00, 0xa5, 0x7f, 0x1c, 0xbc, 0x52, 0x5c, 0x83, 0x7b, 0xb6, 0x8e, 0x0e, 0xd9, 0x79, 0xc1, 0x4e, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0xa6, 0x75, 0x37, 0x1e, 0x96, 0x4f, 0x16, 0x61, 0x91, 0xef, 0x29, 0xb3, 0xc7, 0x80, 0x0b, 0x30, 0x49, 0x4e, 0x47, 0x77, 0x9b, 0xd0, 0x74, 0xfb, 0x00, 0x49, 0xb4, 0x90, 0x7b, 0x33, 0x08, 0xea, 0xcd, 0x21, 0x46, 0x8f, 0x4c, 0xbe, 0xb2, 0xfd, 0xa1, 0xc6, 0x94, 0x26, 0xb1, 0xa7, 0xd6, 0x69, 0x48, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x51, 0xa7, 0xfa, 0x7d, 0xd9, 0x55, 0x8a, 0x90, 0xa3, 0x8c, 0xf0, 0xf3, 0xd5, 0xe0, 0xad, 0xcc, 0x00, 0x99, 0xc3, 0x03, 0x11, 0xc2, 0x28, 0xf4, 0x0d, 0x04, 0x9f, 0x5b, 0x81, 0x56, 0x53, 0x0f, 0xd7, 0x3e, 0xe0, 0xb9, 0x23, 0x0d, 0x6d, 0x17, 0x14, 0xe3, 0x30, 0x3c, 0x19, 0x59, 0xd6, 0x81, 0x4a, 0x45, 0x59, 0x5f, 0x46, 0x4f, 0x52, 0x5f, 0x30, 0x12, 0x5c, 0x44, 0x74, 0xe9, 0x2e, 0x53, 0x5b, 0xe2, 0xd0, 0x77, 0x72, 0x13, 0xcb, 0x2b, 0xdb, 0x25, 0x1a, 0xc3, 0xc9, 0x83, 0x75, 0xac, 0x98, 0xab, 0x1b, 0x71, 0x49, 0x59, 0xd3, 0x6e, 0x7c, 0xb8, 0x3c, 0xcb, 0x28, 0xf4, 0xf8, 0xe6, 0xf7, 0xd6, 0x91, 0xb8, 0x8e, 0x77, 0x75, 0xbd, 0xe2, 0x89, 0x4d, 0x5f, 0xe9, 0x33, 0x5f, 0xdd, 0xae, 0x38, 0xaf, 0xa4, 0xe0, 0x65, 0x32, 0x04, 0x77, 0x9b, 0xc6, 0xe4, 0x8d, 0xdd, 0x1c, 0xdf, 0x58, 0x79, 0xf9, 0xab, 0x90, 0xd4, 0x78, 0xa1, 0xaf, 0x20, 0x99, 0x5d, 0xb0, 0x61, 0x37, 0xcd, 0x28, 0x82, 0x4b, 0xb6, 0x65, 0xa3, 0x32, 0xeb, 0x94, 0x94, 0x00, 0x6d, 0x7e, 0xab, 0x18, 0x5d, 0x41, 0x28, 0x5c, 0x63, 0x11, 0x29, 0xe2, 0x15, 0xd3, 0xfb, 0xb4, 0x9e, 0x4a, 0x36, 0x11, 0xd7, 0x6a, 0x64, 0x8e, 0x7a, 0x2d, 0x50, 0x1f, 0x83, 0x6f, 0x88, 0x27, 0x7f, 0xc3, 0x5e, 0xe9, 0x25, 0x43, 0x40, 0x11, 0x35, 0x6e, 0x4f, 0x55, 0x0a, 0xcc, 0xd8, 0xf7, 0x7e, 0xaa, 0x54, 0xed, 0xd2, 0x33, 0x58, 0x23, 0x66, 0x56, 0x84, 0xf3, 0x92, 0xa2, 0xf1, 0xff, 0x78, 0xf9, 0x0d, 0x01, 0x32, 0xa3, 0xd4, 0x8e, 0x71, 0x9c, 0x76, 0xe8, 0x31, 0xa1, 0xcc, 0x93, 0x88, 0x50, 0xef, 0xa5, 0x1b, 0xff, 0xe1, 0x0c, 0x4a, 0x31, 0x5b, 0x09, 0x01, 0xbc, 0x4b, 0x3f, 0xf2, 0x84, 0x32, 0x86, 0x96, 0xe8, 0x94, 0x03, 0x8f, 0x91, 0x76, 0xfd, 0x84, 0x76, 0xfc, 0x45, 0x05, 0x57, 0x53, 0x6f, 0x79, 0xc2, 0x94, 0x92, 0x0f, 0x22, 0x1f, 0x9f, 0x66, 0x64, 0x70, 0xe8, 0xc8, 0x41, 0x8b, 0x4c, 0x43, 0x98, 0xa9, 0xc6, 0xea, 0x8a, 0x30, 0xcf, 0xb8, 0xe4, 0x9a, 0xce, 0x49, 0xf0, 0x5b, 0x63, 0x3b, 0x47, 0xe6, 0x60, 0x40, 0xf1, 0x4a, 0x00, 0x7b, 0xe6, 0x98, 0xfa, 0xf6, 0x7d, 0x15, 0x3b, 0x64, 0x21, 0x97, 0x44, 0x1e, 0x67, 0xc0, 0x99, 0x8d, 0x2c, 0xe6, 0x19, 0xbf, 0xd4, 0x5b, 0x7b, 0x08, 0x26, 0x0b, 0x0a, 0x64, 0x1a, 0x15, 0x65, 0x18, 0xbf, 0x7b, 0x8b, 0x29, 0xa1, 0x37, 0xa8, 0x4c, 0xa8, 0xf9, 0x31, 0x09, 0x06, 0xc3, 0x2a, 0xb2, 0xc6, 0xe6, 0xf1, 0x84, 0x3a, 0xce, 0x05, 0xd8, 0xbf, 0x14, 0x67, 0x35, 0xc3, 0xcd, 0x92, 0x39, 0xad, 0x15, 0x3a, 0x1d, 0x7a, 0xe8, 0xf0, 0xb1, 0xea, 0x36, 0xfa, 0x62, 0x38, 0xe4, 0x54, 0xba, 0x91, 0xde, 0xb4, 0xcd, 0x45, 0x53, 0x52, 0x4a, 0x44, 0x70, 0x9a, 0xd8, 0xd7, 0xbc, 0x11, 0x9e, 0x8e, 0x71, 0x36, 0x76, 0x80, 0xf2, 0xcc, 0x56, 0x4c, 0xa1, 0x36, 0xe4, 0x6c, 0x04, 0xd5, 0x41, 0xf8, 0x20, 0x91, 0x67, 0x1f, 0x7c, 0xff, 0x39, 0xf2, 0x1d, 0xf6, 0xab, 0xf0, 0xcf, 0xcd, 0xf5, 0xaa, 0x9c, 0x9f, 0xdd, 0xfe, 0x52, 0x7e, 0xd8, 0xc5, 0x69, 0x48, 0xd8, 0x24, 0x6c, 0xa7, 0x81, 0x3b, 0xd8, 0xb6, 0x1d, 0xd6, 0x64, 0x30, 0x67, 0x58, 0x14, 0x5b, 0x4d, 0xdf, 0xba, 0x49, 0xe0, 0x32, 0xfa, 0xff, 0x46, 0xd2, 0xae, 0x66, 0x71, 0x44, 0x2f, 0xf9, 0x5e, 0xda, 0x5c, 0xfa, 0x34, 0xcb, 0x04, 0xa5, 0xcf, 0x07, 0x5a, 0x2c, 0xd2, 0xa1, 0x86, 0x09, 0xbe, 0x29, 0xce, 0x79, 0x79, 0x07, 0x0e, 0x4d, 0xc7, 0xc9, 0xdd, 0x97, 0x1a, 0x2a, 0x62, 0x0f, 0x8c, 0xbe, 0x60, 0x59, 0x0e, 0xeb, 0xc7, 0x96, 0x00, 0xd0, 0xeb, 0x25, 0xb4, 0x62, 0x66, 0x91, 0xe9, 0x58, 0xa6, 0x54, 0xd8, 0x0c, 0xcd, 0xc1, 0xef, 0x18, 0x81, 0xb5, 0xe1, 0x04, 0xb9, 0xb1, 0x13, 0x50, 0x58, 0xba, 0x99, 0x8f, 0x35, 0x90, 0x1c, 0x95, 0x58, 0x63, 0xaa, 0x83, 0x58, 0xfd, 0x99, 0x1d, 0x4b, 0x8c, 0xaa, 0xe6, 0xf9, 0x43, 0xa2, 0x55, 0xba, 0xe9, 0x1a, 0xec, 0x3e, 0xf5, 0x24, 0x8f, 0x2e, 0x91, 0x15, 0x0d, 0x5f, 0x1a, 0xb9, 0x05, 0xa1, 0xde, 0x6c };
        public Dictionary<string, byte[]> modifiedFiles = new Dictionary<string, byte[]>();

        public MainForm()
        {
            InitializeComponent();
            tbLog.AppendText("Version 1.0" + Environment.NewLine);
            tbLog.AppendText("DBO TW Crypto Tools by SanGawku" + Environment.NewLine);
            tbLoadPath.Text = Environment.CurrentDirectory;
            tbSavePath.Text = Environment.CurrentDirectory;

        }

        private FolderBrowserDialog fbdLoadxDF;
        private FolderBrowserDialog fbdSavexDF;

        private void btnBrowseOpenFiles_Click(object sender, EventArgs e)
        {
            fbdLoadxDF = new System.Windows.Forms.FolderBrowserDialog();
            fbdLoadxDF.Description = "Select the directory that contains the Files you wish to convert.";
            fbdLoadxDF.RootFolder = Environment.SpecialFolder.Desktop;
            fbdLoadxDF.SelectedPath = Environment.CurrentDirectory;
            DialogResult result = fbdLoadxDF.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbLoadPath.Text = fbdLoadxDF.SelectedPath;
            }
        }

        private void btnSaveFilePath_Click(object sender, EventArgs e)
        {
            fbdSavexDF = new System.Windows.Forms.FolderBrowserDialog();
            fbdSavexDF.Description = "Select the directory to save converted files.";
            fbdSavexDF.RootFolder = Environment.SpecialFolder.Desktop;
            fbdSavexDF.SelectedPath = Environment.CurrentDirectory;
            DialogResult result = fbdSavexDF.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbSavePath.Text = fbdSavexDF.SelectedPath;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            //Make sure everything is cleared out before attempting. 
            modifiedFiles.Clear();
            modifiedFileBytes.Clear();

            string[] files = GetFiles(tbLoadPath.Text, "*.rdf|*.edf", SearchOption.TopDirectoryOnly);
            if(files.Length == 0)
            {
                DarkMessageBox.Show(this, "No Files found, Please select a directory with Dragon Ball Online Tw table files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
            tbLog.AppendText("Files found: " + files.Length.ToString() + Environment.NewLine);
            tbLog.AppendText("Begining Decryption/Encryption of files." + Environment.NewLine);

            foreach (string fileName in files)
                ConvertEncryption(fileName);

            tbLog.AppendText("All Files Processed.");
            foreach(var f in modifiedFiles)
            {
                File.WriteAllBytes(tbSavePath.Text + "\\" + f.Key, f.Value);
            }
            tbLog.AppendText("All Files Saved");
        }

        private static string[] GetFiles(string sourceFolder, string filters, System.IO.SearchOption searchOption)
        {
            return filters.Split('|').SelectMany(filter => System.IO.Directory.GetFiles(sourceFolder, filter, searchOption)).ToArray();
        }

        private void ConvertEncryption(string fileName)
        {
            var bytes = File.ReadAllBytes(fileName);

            tbLog.AppendText(("Processing " + Path.GetFileName(fileName) + "." + Environment.NewLine));
            //Make sure the list is cleared.
            modifiedFileBytes.Clear();

            for (int i = 0; i < bytes.Length; i++)
            {
                //Encryption is not really encryption but a simple repeated key XOR cipher. 
                modifiedFileBytes.Add((byte)(bytes[i] ^ TheKey[i % TheKey.Length]));
            }
            if (fileName.Contains("rdf"))
                modifiedFiles.Add(Path.GetFileNameWithoutExtension(fileName) + ".edf", modifiedFileBytes.ToArray());
            else
                modifiedFiles.Add(Path.GetFileNameWithoutExtension(fileName) + ".rdf", modifiedFileBytes.ToArray());

            modifiedFileBytes.Clear();
            tbLog.AppendText((Path.GetFileName(fileName) + " processed." + Environment.NewLine));
        }


    }
}
