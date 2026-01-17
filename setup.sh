#!/bin/bash

# Playwright C# Project Setup Script
# This script initializes the Playwright project with all necessary browser installations

echo "========================================="
echo "Playwright C# Setup Script"
echo "========================================="
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null; then
    echo "ERROR: .NET CLI is not installed. Please install .NET 8.0 or later."
    exit 1
fi

echo "✓ .NET CLI found"
echo ""

# Restore NuGet packages
echo "Installing NuGet packages..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "ERROR: Failed to restore packages"
    exit 1
fi
echo "✓ Packages restored successfully"
echo ""

# Build the project
echo "Building the project..."
dotnet build
if [ $? -ne 0 ]; then
    echo "ERROR: Build failed"
    exit 1
fi
echo "✓ Project built successfully"
echo ""

# Install Playwright browsers
echo "Installing Playwright browsers..."
dotnet exec bin/Debug/net8.0/playwright.ps1 install 2>/dev/null || \
dotnet tool install --global PlaywrightSharp.CLI && \
playwright install
if [ $? -ne 0 ]; then
    echo "ERROR: Failed to install Playwright browsers"
    exit 1
fi
echo "✓ Playwright browsers installed"
echo ""

echo "========================================="
echo "Setup Complete!"
echo "========================================="
echo ""
echo "Next steps:"
echo "1. Update appsettings.json with your test environment URL"
echo "2. Update selectors in page objects for your application"
echo "3. Create additional page objects as needed"
echo "4. Run tests with: dotnet test"
echo ""
