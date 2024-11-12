using Microsoft.EntityFrameWorkCore;

namespace NoteKeeper.Infra.Orm.Compartilhado;

public static class MigradorBancoDados
{
    public static bool AtualizarBancoDados(DbContext dbContext)
    {
        var qtdMigracoesPendentes = dbContext.Datadabe.GetPendingMigrations().Count();

        if (qtdMigracoesPendentes == 0)
        {
            Console.WriteLine("Nenhuma migração pendente, continuando...");

            return false;
        }

        Console.WriteLine("Aplicando migrações pendentes, isso pode demorar alguns segundos...");

        dbContext.Datadabe.Migrate();

        return true;
    }
}