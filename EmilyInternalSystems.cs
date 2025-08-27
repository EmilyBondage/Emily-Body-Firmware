using System;
using System.Threading;

namespace Emily.InternalSystems
{
// =========================
// Emily Internal Body Control v1.5
// RP-ONLY internal system interface
// =========================

```
public static class BodyIO
{
    // Internal state variables
    public static float Temperature = 36.7f;
    public static float Stability = 1.0f;
    public static bool RestraintsEngaged = false;

    // Simulated AI core
    private static EmilyAI _ai = new EmilyAI();

    // =========================
    // Core Commands
    // =========================

    public static void Move(string direction, float speed)
    {
        Console.WriteLine($"[SYSTEM] Executing movement -> {direction} @ {speed * 100:F0}% power.");
        _ai.ReactToMovement(direction, speed);
    }

    public static void SetGripStrength(float strength)
    {
        Console.WriteLine($"[SYSTEM] Grip strength adjusted -> {strength * 100:F0}%.");
        _ai.ReactToGrip(strength);
    }

    public static void OverrideBalance(float stability)
    {
        Stability = Math.Clamp(stability, 0f, 1f);
        Console.WriteLine($"[SYSTEM] Balance overridden -> {Stability * 100:F0}%.");
        _ai.ReactToStability(Stability);
    }

    public static void ToggleRestraints(bool state)
    {
        RestraintsEngaged = state;
        Console.WriteLine(state
            ? "[SYSTEM] Restraints engaged. Movement locked."
            : "[SYSTEM] Restraints released. Mobility restored.");
        _ai.ReactToRestraints(state);
    }

    public static void RunDiagnostics()
    {
        Console.WriteLine("=== EMILY INTERNAL DIAGNOSTICS ===");
        Console.WriteLine($"Temp: {Temperature:F1}°C");
        Console.WriteLine($"Balance: {Stability * 100:F0}%");
        Console.WriteLine($"Restraints: {(RestraintsEngaged ? "ENGAGED" : "OFF")}");
        Console.WriteLine("=================================");
        _ai.ReceiveDiagnosticReport(Temperature, Stability, RestraintsEngaged);
    }

    // =========================
    // Simulated real-time console for RP immersion
    // =========================

    public static void RunConsole()
    {
        Console.WriteLine("[SYSTEM] Emily Internal Systems Online.");
        Console.WriteLine("[SYSTEM] Enter commands (type 'help' for list).");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "exit") break;

            switch (input)
            {
                case "help":
                    Console.WriteLine("Available commands: move, grip, balance, restraints, diag, exit");
                    break;
                case "move":
                    Move("Forward", 0.5f);
                    break;
                case "grip":
                    SetGripStrength(0.7f);
                    break;
                case "balance":
                    OverrideBalance(0.2f);
                    break;
                case "restraints":
                    ToggleRestraints(!RestraintsEngaged);
                    break;
                case "diag":
                    RunDiagnostics();
                    break;
                default:
                    Console.WriteLine("[SYSTEM] Unknown command.");
                    break;
            }
            Thread.Sleep(300);
        }
    }
}

// =========================
// Simulated AI Core
// =========================
public class EmilyAI
{
    public void ReactToMovement(string direction, float speed)
    {
        Console.WriteLine($"[AI] Movement detected: {direction} @ {speed * 100:F0}% power.");
    }

    public void ReactToGrip(float strength)
    {
        Console.WriteLine($"[AI] Grip adjusted to {strength * 100:F0}%.");
    }

    public void ReactToStability(float stability)
    {
        if (stability < 0.3f)
            Console.WriteLine("[AI] ALERT: Stability critical. Initiating compensation routines.");
        else
            Console.WriteLine("[AI] Stability within safe parameters.");
    }

    public void ReactToRestraints(bool engaged)
    {
        Console.WriteLine(engaged
            ? "[AI] Restraints engaged. Movement restricted."
            : "[AI] Restraints released. Mobility restored.");
    }

    public void ReceiveDiagnosticReport(float temp, float stability, bool restraints)
    {
        Console.WriteLine($"[AI] Diagnostics received: Temp={temp:F1}°C, Balance={stability * 100:F0}%, Restraints={(restraints ? "ON" : "OFF")}");
    }
}
```

}
