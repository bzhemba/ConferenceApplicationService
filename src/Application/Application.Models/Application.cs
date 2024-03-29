﻿namespace Application.Models;

public record Application(Guid Id, Guid UserId, ActivityType Activity, string Title, string? Description, string Plan);