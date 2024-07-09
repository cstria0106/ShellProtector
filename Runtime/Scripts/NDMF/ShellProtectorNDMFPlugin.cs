#if UNITY_EDITOR
#if MODULAR
using nadena.dev.ndmf;
using Shell.Protector;
using UnityEngine;

[assembly: ExportsPlugin(typeof(ShellProtectorNDMFPlugin))]

public class ShellProtectorNDMFPlugin : Plugin<ShellProtectorNDMFPlugin>
{
    protected override void Configure()
    {
        InPhase(BuildPhase.Generating)
        .BeforePlugin("nadena.dev.modular-avatar")
        .Run("Encrypting", ctx =>
        {
            Debug.Log("Encrypting Shell Protector");
            if (ctx.AvatarRootObject.TryGetComponent<ShellProtector>(out var shellProtector))
            {
                shellProtector.Encrypt(clone: false);
            }
        });
    }
}
#endif
#endif