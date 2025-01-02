/// <summary>
/// Defines a contract for classes that support matrix-based transformations.
/// </summary>
/// <typeparam name="T">The type of the implementing class.</typeparam>
/// <typeparam name="TMatrix">The type of the matrix used for transformations.</typeparam>
public interface IMatrixTransformations<T, TMatrix>
{
    /// <summary>
    /// Gets the current matrix associated with the implementing object.
    /// </summary>
    /// <returns>The matrix of type <typeparamref name="TMatrix"/>.</returns>
    TMatrix GetMatrix();

    /// <summary>
    /// Sets the matrix for the implementing object.
    /// </summary>
    /// <param name="matrix">The matrix of type <typeparamref name="TMatrix"/> to set.</param>
    void SetMatrix(TMatrix matrix);

    /// <summary>
    /// Creates a new instance of the implementing class from the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix of type <typeparamref name="TMatrix"/> to use for creating the new instance.</param>
    /// <returns>A new instance of type <typeparamref name="T"/> created from the specified matrix.</returns>
    T CreateFromMatrix(TMatrix matrix);
}
