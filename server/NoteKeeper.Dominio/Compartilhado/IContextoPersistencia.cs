﻿namespace NoteKeeper.Dominio.Compartilhado;

public interface IContextoPersistencia
{
    Task<bool> GravarAsync();
}