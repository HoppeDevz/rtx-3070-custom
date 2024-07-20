# 🖥️ RTX 3070 Custom

This repository contains code for an ESP32 microcontroller and a Windows executable using Windows Forms and .NET Framework. Together, they form a system consisting of a custom display for an RTX 3070 graphics card, showing GPU usage and temperature.

IMG_01                     |  IMG_02
:-------------------------:|:-------------------------:
![](https://i.imgur.com/0mozlfX.jpeg)  |  ![](https://i.imgur.com/WYAdtk9.jpeg)

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project was developed to provide a visual and customized way to monitor the performance of your RTX 3070 graphics card. The system uses an ESP32 microcontroller to control a display that shows GPU usage and temperature information.

## Features

- Real-time monitoring of GPU usage
- Display of GPU temperature
- User-friendly interface

## Installation

### Prerequisites

- ESP32 microcontroller
- Display compatible with ESP32
- Development environment for ESP32 (Arduino IDE, PlatformIO, etc.)
- Windows 10 or higher
- .NET Framework 4.7 or higher

### ESP32 Setup

1. Connect your ESP32 to your computer.
2. Open your development environment (Arduino IDE, PlatformIO, etc.).
3. Load the ESP32 code from the `esp32` directory.
4. Compile and upload the code to the ESP32.

### Windows Setup

1. Download the Windows executable from the `windows` directory.
2. Run the installer and follow the on-screen instructions.

## Usage

1. Power on your ESP32 and connect it to the display.
2. Run the Windows application.
3. The display will show the GPU usage and temperature in real-time.

## Project Structure

```plaintext
rtx-3070-custom/
├── esp32/                  # Code for ESP32 microcontroller
│   ├── src/                # Source files
│   └── include/            # Header files
├── windows/                # Windows executable
│   ├── bin/                # Binary files
│   ├── src/                # Source files
│   └── include/            # Header files
├── README.md               # This file
└── LICENSE                 # License file
