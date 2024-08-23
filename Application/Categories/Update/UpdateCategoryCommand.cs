﻿using Application.Abstractions.Messaging;

namespace Application.Categories.Update;

public sealed record UpdateCategoryCommand(Guid CategoryId, string FullName, string ShortName)
    : ICommand<Guid>;
