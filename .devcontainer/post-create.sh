#!/bin/bash
set -e

echo "🚀 Setting up development environment..."

# Restore .NET dependencies
echo "📦 Restoring .NET dependencies..."
if [ -f "src/plugin-arch-event-handler-grpc-server.sln" ]; then
    dotnet restore src/plugin-arch-event-handler-grpc-server.sln
else
    echo "⚠️  Solution file not found, skipping .NET restore"
fi

# Make scripts executable
echo "🔧 Setting up scripts..."
if [ -f "wrapper.sh" ]; then
    chmod +x wrapper.sh
fi

# Configure git for safe directory
if [ -d ".git" ]; then
    echo "🔧 Setting up git..."
    git config --global --add safe.directory /workspace
fi

echo "✅ Development environment setup complete!"
echo ""
echo "🎯 Quick start commands:"
echo "  • Build .NET solution: dotnet build src/plugin-arch-event-handler-grpc-server.sln"
echo "  • Run .NET service: cd src/AccelByte.PluginArch.EventHandler.Demo.Server && dotnet run"
echo ""
echo "🛟 Ports:"
echo "  • gRPC Server: 6565"
echo "  • Prometheus Metrics: 8080"
