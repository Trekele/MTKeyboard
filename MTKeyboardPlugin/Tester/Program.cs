using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTKeyboardPlugin;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Plugin plugin = new Plugin();

            plugin.Initialize(null);

            string example1 = @"{
              'info': {
                'me': {
                  'goals': '1'
                }
              },
              'feature': 'me'
            }";
            string example2 = @"{
              'info': {
                'me': {
                  'goals': '2'
                }
              },
              'feature': 'me'
            }";
            string example3 = @"{
              'info': {
                'me': {
                  'goals': '3'
                }
              },
              'feature': 'me'
            }";
            string example4 = @"{
              'info': {
                'me': {
                  'goals': '4'
                }
              },
              'feature': 'me'
            }";
            plugin.handleInfoUpdates2(example1, null);
            plugin.handleInfoUpdates2(example2, null);
            plugin.handleInfoUpdates2(example3, null);
            plugin.handleInfoUpdates2(example4, null);
        }
    }
}
