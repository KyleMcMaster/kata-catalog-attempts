export class Player {
  score: number;
  name: string;

  constructor(options: {
    score?: number;
    name?: string,
  }) {
    // setup base player with defaults
    this.score = options.score || 0;
    this.name = options.name || "";
  }

  // score points
  scorePoints(points: number) {
    this.score += points;
  }
}
